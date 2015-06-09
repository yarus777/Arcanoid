using System.Collections.Generic;

using Assets.Scripts.Game.Blocks.Creators;
using Assets.Scripts.Game.State.FailReasons;
using Assets.Scripts.Game.State.WinReasons;
using Assets.Scripts.Serialization.Levels;

namespace Assets.Scripts.Game.Levels {
    class Level {
        private readonly List<IFailReason> _failReasons;
        private readonly List<IWinReason> _winReasons;
        private readonly IEnumerable<BlockInfo> _blocks;
        public int Number { get; private set; }

        public IEnumerable<IFailReason> FailReasons {
            get {
                return _failReasons;
            }
        }

        public IEnumerable<IWinReason> WinReasons {
            get {
                return _winReasons;
            }
        }
        

        public Level(IEnumerable<BlockInfo> blocks) {
            _failReasons = new List<IFailReason>();
            _winReasons = new List<IWinReason>();
            _blocks = blocks;
            _failReasons.Add(new BallLostReason());
            _winReasons.Add(new FieldClearedReason());
        }

        public virtual BlockCreator BlockCreator {
            get {
                return new RestoringBlockCreator(_blocks);
            }
        }
    }
}
