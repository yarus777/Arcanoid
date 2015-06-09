using System.Collections.Generic;
using System.Linq;

using Assets.Scripts.Engine.State.Serializers;
using Assets.Scripts.Engine.State.StateSavers;
using Assets.Scripts.Game.Levels;
using Assets.Scripts.Parameters;
using Assets.Scripts.Serialization.Levels;

namespace Assets.Scripts.Engine.Loading {
    class LevelLoader {
        public List<Level> Load() {
            var loader = new XmlScopeReader(new ResourceScopeReader());
            var levelsInfo = loader.LoadAll<LevelInfo>(Strings.LEVELS_PATH);
            return levelsInfo.Select(lvl => LevelBuilder.Restore(lvl)).ToList();
        }
    }
}
