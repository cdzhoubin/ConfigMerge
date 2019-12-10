using ConfigMerge.Services;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;
using System.Text;

namespace ConfigMerge.WinForm
{
    public class RecipeService:ServiceBase
    {
        readonly string file;
        public RecipeService()
        {
            file = string.Format("{0}\\{1}", ApplictionData, "RecipeData.json");
        }

        private void SaveData(RecipeConfigList data)
        {
            File.WriteAllText(file, JsonConvert.SerializeObject(data), Encoding.UTF8);
        }
        public string Save(RecipeConfigEntity entity)
        {
            var list = Get();
            bool repeat = false;
            if(entity.Id == Guid.Empty)
            {
                repeat = list.Any(p => p.Classify == entity.Classify && p.Name == entity.Name);
            } else
            {
                repeat = list.Any(p => p.Classify == entity.Classify && p.Name == entity.Name && p.Id != entity.Id);
            }
            if (repeat)
            {
                return "同一分类下，已经存在相关名称记录。";
            }
            if(entity.Id == Guid.Empty)
            {
                entity.Id = Guid.NewGuid();
            } else
            {
                var p = list.First(w => w.Id == entity.Id);
                list.Remove(p);
            }
            list.Add(entity);
            SaveData(list);
            return "";
        }
        public RecipeConfigList Get()
        {
            if (File.Exists(file))
            {
                var data = JsonConvert.DeserializeObject<RecipeConfigList>(File.ReadAllText(file));
                return data;
            }
            else
            {
                return new RecipeConfigList();
            }
        }

        public RecipeConfigEntity Get(Guid id)
        {
            return Get().Where(p => p.Id == id).FirstOrDefault();
        }

        public string Merge(RecipeConfigEntity entity)
        {

            FileInfo fi = new FileInfo(entity.OutputConfigFile);
            DirectoryInfo di = new DirectoryInfo(entity.InputConfigFolder);
            if (!di.Exists)
            {
                return "输入目录不存在。";
            }
            if (!di.GetFiles("*.config").Any())
            {
                return "输入目录没有配置文件。";
            }
            var name = string.Format("{0}.recipe", Guid.NewGuid().ToString().Replace("-", ""));
            string fileName = string.Format("{0}{1}", ApplictionDataTemp, name);
            try
            {
                CreateRecipe(fileName, fi,di);
                ConfigMergeTools.Merge(name);
            }
            finally
            {
                if (File.Exists(fileName))
                {
                    File.Delete(fileName);
                }
            }
            return "";
        }
        private string CreateRecipe(string fileName, FileInfo outputFile, DirectoryInfo inputDirectory)
        {
            StringBuilder sb = new StringBuilder();
            
            foreach(var fi in inputDirectory.GetFiles("*.config").OrderBy(p=>p.Name))
            {
                sb.AppendFormat("{0},", fi.Name);
            }
            string str = string.Format(FormatRecipe, inputDirectory.FullName, outputFile.Directory.FullName, outputFile.Name, sb.ToString().TrimEnd('\n'));
            File.WriteAllText(fileName, str);
            return fileName;
            //StringBuilder sb = new StringBuilder();
            //sb.AppendFormat("{0}=[", Entity.OutputConfigFile);
            //for (int i = 0; i < Entity.InputConfigFiles.Count; i++)
            //{
            //    sb.Append(Entity.InputConfigFiles[i]);
            //    if (i != Entity.InputConfigFiles.Count - 1)
            //    {
            //        sb.Append(",");
            //    }
            //}
            //sb.Append("];");
            //return sb.ToString();
        }

        private static string FormatRecipe = @"# Folder ""input/"" stored in variable inputFolder
var inputFolder = ""{0}"";
var outputFolder = ""{1}"";
outputFolder + {2} = inputFolder + [{3}];

# Non-absolute file paths are relative to Web.config.recipe's parent folder
# Last file wins
# Non-existing files are ignored

# Create ./output/Web.test.config by merging ./input/Web.root.config, input/Web.test.override.config and input/Web.dev.config
# Web.dev.config might not be tracked by source control
#outputFolder + Web.test.config = inputFolder + [Web.root.config, Web.test.override.config, Web.dev.config];

# Create ./output/Web.prod.config by merging ./input/Web.root.config and input/Web.prod.override.config
#outputFolder + Web.prod.config = inputFolder + [Web.root.config, Web.prod.override.config];

# Create output based on input/Web.input1.config, input/Web.input2.config, etc.
#Web.manyinputs.config = inputFolder + ""Web."" + [input1, input2, input3, input4] + .config;";

    }
}
