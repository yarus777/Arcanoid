using System.Linq;

using UnityEngine;

namespace Assets.Scripts.Engine.State.StateSavers {
    class ResourceScopeReader : ResourceStateLoader, ILoadAll {
        public string[] LoadAll(string path) {
            return Resources.LoadAll<TextAsset>(path).Select(asset => asset.text).ToArray();
        }
    }
}
