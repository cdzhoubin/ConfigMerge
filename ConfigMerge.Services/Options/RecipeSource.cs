using System.IO;
using ConfigMerge.Services.Core;
using ConfigMerge.Services.Core.Lang;

namespace ConfigMerge.Services.Options
{
    public static class RecipeSource
    {
        public static IRecipeSource FromFileOrInput(string input)
        {
            if (File.Exists(input))
            {
                return new RecipeFile(input);
            }
            return new RecipeString(input);
        }
    }
}