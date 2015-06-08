using System.Collections.Generic;
using System.Xml.Serialization;

namespace Assets.Scripts.Serialization.Levels {
    [XmlRoot("Level")]
    public class LevelInfo {
        [XmlElement("Number")]
        public int Number { get; set; }

        [XmlArray("Blocks")]
        [XmlArrayItem("Block")]
        public List<BlockInfo> Blocks { get; private set; }

        public LevelInfo() {
            Blocks = new List<BlockInfo>();
        }
    }
}
