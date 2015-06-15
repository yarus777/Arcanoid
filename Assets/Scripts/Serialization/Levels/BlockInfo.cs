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

        [XmlElement("Bonus")]
        public BonusType? Bonus { get; set; }
        public BlockInfo(int x, int y, BlockType type, BonusType? bonus = null) {
            X = x;
            Y = y;
            Type = type;
            Bonus = bonus;
        }

        public BlockInfo() {
        }

        public void Transpone(int byX, int byY) {
            X += byX;
            Y += byY;
        }
    }
}
