using System.Collections.Generic;

using Assets.Scripts.Game.State.FailReasons;
using Assets.Scripts.Game.State.WinReasons;

namespace Assets.Scripts.Game.Levels {
    class Level {
        private List<IFailReason> _failReasons;
        public IEnumerable<IFailReason> FailReasons {
            get {
                return _failReasons;
            }
        }

        private List<IWinReason> _winReasons;

        public IEnumerable<IWinReason> WinReasons {
            get {
                return _winReasons;
            }
        }

        public Level() {
            _failReasons = new List<IFailReason>();
            _winReasons = new List<IWinReason>();
        }
    }
}
