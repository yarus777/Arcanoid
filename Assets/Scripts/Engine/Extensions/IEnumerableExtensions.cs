using System.Collections.Generic;
using System.Linq;

namespace Assets.Scripts.Engine.Extensions {
    public static class IEnumerableExtensions {
        public static T Random<T>(this IEnumerable<T> items) {
            var list = items.ToList();
            return list[UnityEngine.Random.Range(0, list.Count)];
        }
    }
}
