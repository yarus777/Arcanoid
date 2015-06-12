using System.Collections.Generic;
using System.Linq;

using Assets.Scripts.Game.GameInterfaces;
using Assets.Scripts.Game.Levels;

namespace Assets.Scripts.Game.Bonuses {
    class BonusController : IGameComponent {
        private List<IBonus> _bonuses;

        #region IGameComponent

        public void StartGame(Level level) {
            //_bonuses = level.Blocks.SelectMany(block => block.Bonuses);
        }

        public void FinishGame() {
        }

        #endregion
    }
}
