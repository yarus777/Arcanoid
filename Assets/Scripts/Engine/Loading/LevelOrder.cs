using System.Collections.Generic;

namespace Assets.Scripts.Engine.Loading {
    static class LevelOrder {
        public static readonly Dictionary<int, string> Scenes = new Dictionary<int, string>() { { 0, "MenuScene" }, { 1, "MapScene" }, { 2, "GameScene" } };
    }
}
