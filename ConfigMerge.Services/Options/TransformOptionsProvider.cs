using ConfigMerge.Services.Core.Merging;
using ConfigMerge.Services.Services.Options;

namespace ConfigMerge.Services.Options
{
    public class TransformOptionsProvider
    {
        public static TransformOptions GetTransformOptions()
        {
            var options = new TransformOptions();
            var overrides = OverrideTransformOptions.FromConfig();

            options.DeleteKeyword = overrides.DeleteKeyword ?? options.DeleteKeyword;
            options.EnableTrace = overrides.EnableTrace.GetValueOrDefault(options.EnableTrace);
            options.UniqueAttributes = overrides.UniqueAttributes ?? options.UniqueAttributes;
            return options;
        }
    }
}