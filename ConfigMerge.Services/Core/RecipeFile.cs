using System.Collections;
using System.Collections.Generic;
using System.IO;
using ConfigMerge.Services.Core.Lang;

namespace ConfigMerge.Services.Core
{
    public class RecipeFile : IRecipeSource
    {
        public string BasePath { get; }
        public string FullPath { get; }
        public string Name { get; }
        public FileInfo File { get; }

        public RecipeFile(string path)
        {
            File = new FileInfo(path);
            if (!File.Exists)
            {
                throw new FileNotFoundException($"Could not find {path}");
            }
            BasePath = File.Directory?.FullName;
            Name = File.Name;
            FullPath = File.FullName;
        }

        public Stream GetStream()//��ȡ�ļ������ڴ���
        {
            Stream stream = new MemoryStream(System.IO.File.ReadAllBytes(File.FullName));
            return stream;
            //return File.OpenRead();
        }

        public IEnumerator<Token> GetEnumerator()
        {
            return new RecipeLexer(new SourceStreamEnumerator(this));
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public static RecipeFile FromPath(string path)
        {
            return System.IO.File.Exists(path) ? new RecipeFile(path) : null;
        }
    }
}