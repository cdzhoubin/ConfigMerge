using System.Collections.Generic;

namespace ConfigMerge.Services.Core
{
    public interface IConfigTransformer
    {
        void Transform(string outputFile, IEnumerable<string> inputFiles);
    }
}