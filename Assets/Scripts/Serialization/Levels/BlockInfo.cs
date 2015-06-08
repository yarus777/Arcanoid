using System.Xml.Serialization;

using UnityEngine;

namespace Assets.Scripts.Serialization.Levels {
    public class BlockInfo : SavedInfo {
        [XmlElement("Type")]
        public BlockType Type;

        [XmlElement("Position")]
        public Vector2 Position;

        [XmlElement("Size")]
        public Vector2 Size;

        public BlockInfo() {
            Size = new Vector2(128, 70);
        }
    }
}
