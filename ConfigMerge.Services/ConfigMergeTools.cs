using ConfigMerge.Services.Core;
using ConfigMerge.Services.Core.Lang;
using ConfigMerge.Services.Logging;
using ConfigMerge.Services.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ConfigMerge.Services
{
    public static class ConfigMergeTools
    {
        public static void Merge(string recipe, LogLevel logLevel = LogLevel.Normal)
        {
           Logger.Level = logLevel;
            var source = RecipeSource.FromFileOrInput(recipe);
            var recipeExpress = new RecipeParser(source).Recipe;
            var options = TransformOptionsProvider.GetTransformOptions();
            recipeExpress.Compile()(new ConfigTransformer(source.BasePath, options));
        }
        public static void SetLogger(ILoggerCreator loggerCreator)
        {
            LoggerFactory.SetLoggerFunction(loggerCreator);
        }
    }
}
