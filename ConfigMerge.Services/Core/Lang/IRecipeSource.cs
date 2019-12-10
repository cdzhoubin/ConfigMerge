using System.Collections.Generic;
using System.IO;

namespace ConfigMerge.Services.Core.Lang
{
    public interface IRecipeSource : IEnumerable<Token>
    {
        string BasePath { get; }
        string FullPath { get; }
        string Name { get; }
        Stream GetStream();
    }
}