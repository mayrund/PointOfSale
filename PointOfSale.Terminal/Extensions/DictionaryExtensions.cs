using System;
using System.Collections.Generic;
using System.Text;

namespace PointOfSale.Terminal.Extensions
{
    public static class DictionaryExtensions
    {
        public static void ForEach<T, U>(this Dictionary<T, U> d, Action<KeyValuePair<T, U>> a)
        {
            foreach (KeyValuePair<T, U> p in d) { a(p); }
        }
    }
}
