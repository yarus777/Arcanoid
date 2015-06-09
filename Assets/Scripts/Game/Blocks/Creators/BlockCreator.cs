using System.Collections.Generic;

using BlockInfo = Assets.Scripts.Serialization.Levels.BlockInfo;

namespace Assets.Scripts.Game.Blocks.Creators {
    abstract class BlockCreator {
        public abstract IEnumerable<BlockInfo> BlocksInfo { get; }
    }
}
