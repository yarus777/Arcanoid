using System.Xml.Serialization;

using UnityEngine;

namespace Assets.Scripts.Serialization.Levels {
    public class BlockInfo : SavedInfo {
        public static readonly Vector2 SIZE = new Vector2(150, 70);

        [XmlElement("Type")]
        public BlockType Type;

        [XmlElement("Position")]
        public Vector2 Position;
    }
}
