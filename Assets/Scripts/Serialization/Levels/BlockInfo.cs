using System.Xml.Serialization;

using Assets.Scripts.Engine.Geometry;

namespace Assets.Scripts.Serialization.Levels {
    public class BlockInfo : SavedInfo, ITransponable {
        [XmlElement("Type")]
        public BlockType Type;

        [XmlElement("X")]
        public int X { get; set; }

        [XmlElement("Y")]
        public int Y { get; set; }

        public BlockInfo() {
        }

        public BlockInfo(int x, int y, BlockType type) {
            X = x;
            Y = y;
            Type = type;
        }

        public void Transpone(int byX, int byY) {
            X += byX;
            Y += byY;
        }
    }
}
