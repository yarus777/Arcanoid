using System.Collections.Generic;
using System.Linq;

using Assets.Scripts.Engine.Geometry;
using Assets.Scripts.Game.Consts;
using Assets.Scripts.Game.State.FailReasons;
using Assets.Scripts.Game.State.WinReasons;
using Assets.Scripts.Serialization.Levels;

namespace Assets.Scripts.Game.Levels {
    class Level {
        private readonly List<IFailReason> _failReasons;
        private readonly List<IWinReason> _winReasons;

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
        

        public Level() {
            _failReasons = new List<IFailReason>();
            _winReasons = new List<IWinReason>();
            _failReasons.Add(new BallLostReason());
            _winReasons.Add(new FieldClearedReason());
        }

        public virtual void Init(LevelInfo level) {
            var matrix = new Matrix(GameConsts.FIELD_WIDTH, GameConsts.FIELD_HEIGHT);
            matrix.SetCells(level.Blocks.Cast<ITransponable>());
            Blocks = matrix.Normalize().Cast<BlockInfo>();
        }

        public IEnumerable<BlockInfo> Blocks { get; protected set; }
    }
}
