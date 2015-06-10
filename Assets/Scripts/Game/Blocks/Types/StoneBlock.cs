using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Serialization;

namespace Assets.Scripts.Game.Blocks.Types
{
    class StoneBlock : Block
    {
        public override BlockType Type
        {
            get { return BlockType.Stone; }
        }
    }
}
