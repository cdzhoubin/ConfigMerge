using System.Collections.Generic;

namespace ConfigMerge.Services.Collections
{
    public interface ISuperEnumerator<out T> : IEnumerator<T>
    {
        bool Moved { get; }
    }
}