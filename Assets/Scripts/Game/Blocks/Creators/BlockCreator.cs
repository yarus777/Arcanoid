using System.Collections;
using System.Collections.Generic;

using Assets.Scripts.Game.Blocks.Data;

namespace Assets.Scripts.Game.Blocks.Creators {
    abstract class BlockCreator {
        public abstract IEnumerable<BlockInfo> BlocksInfo { get; }
    }
}
