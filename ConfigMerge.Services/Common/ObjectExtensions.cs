using System.Linq;

namespace ConfigMerge.Services.Common
{
    public static class ObjectExtensions
    {
        public static bool In<T>(this T value, params T[] values)
        {
            return values.Contains(value);
        }
    }
}