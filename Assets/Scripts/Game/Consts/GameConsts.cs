using UnityEngine;

namespace Assets.Scripts.Game.Consts {
    public class GameConsts {
        public enum Direction {
            Horizontal,
            Vertical
        }

        public enum FieldType {
            Restored,
            Random
        }

        public enum StatisticItems {
            Lives,
            Score
        }

        public static readonly Vector2 BLOCK_SIZE = new Vector2(120, 70);

        public const int FIELD_WIDTH = 8;
        public const int FIELD_HEIGHT = 6;
    }
}
