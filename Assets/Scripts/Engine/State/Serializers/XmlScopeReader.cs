using System.Collections.Generic;
using System.IO;

using Assets.Scripts.Engine.State.StateSavers;

namespace Assets.Scripts.Engine.State.Serializers {
    class XmlScopeReader : XmlReader {
        private readonly ILoadAll _loader;

        public XmlScopeReader(ILoadAll stateLoader)
            : base(stateLoader) {
            _loader = stateLoader;
        }

        public IEnumerable<T> LoadAll<T>(string path) {
            var xmls = _loader.LoadAll(path);
            var serializer = new System.Xml.Serialization.XmlSerializer(typeof(T));
            foreach (var xml in xmls) {
                using (var reader = new StringReader(xml)) {
                    yield return (T)serializer.Deserialize(reader);
                }
            }
        }
    }
}
