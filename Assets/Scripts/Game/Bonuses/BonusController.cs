using System.Collections.Generic;
using Assets.Scripts.Game.Bonuses.Implementations;
using Assets.Scripts.Game.GameInterfaces;
using Assets.Scripts.Game.Levels;
using UnityEngine;

namespace Assets.Scripts.Game.Bonuses {
    class BonusController : MonoBehaviour, IGameComponent {
        [SerializeField]
        private CollectableBonus BonusPrefab;

        private List<IBonus> _bonuses;

        #region IGameComponent

        public void StartGame(Level level) {
            foreach (var blockInfo in level.Blocks) {
                var bonusObj = Instantiate(BonusPrefab.gameObject) as GameObject;
                bonusObj.transform.SetParent(transform);
                bonusObj.transform.localScale = Vector3.one;
                bonusObj.SetActive(false);
            }
        }

        public void FinishGame() {
        }

        #endregion
    }
}
