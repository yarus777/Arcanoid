using System.Collections.Generic;
using System.Linq;

using Assets.Scripts.Game.Blocks;
using Assets.Scripts.Game.Bonuses.Implementations;
using Assets.Scripts.Serialization.Levels;

using UnityEngine;

namespace Assets.Scripts.Game.Bonuses {
    class BonusController : MonoBehaviour {
        [SerializeField]
        private CollectableBonus[] BonusPrefabs;

        private List<IBonus> _bonuses;

        public CollectableBonus CreateBonus(BlockInfo block) {
            if (block.Bonus == null) {
                return null;
            }
            var suitableBonus = BonusPrefabs.FirstOrDefault(b => b.Type == block.Bonus);
            if (suitableBonus == null) {
                return null;
            }
            var bonusObj = Instantiate(suitableBonus.gameObject) as GameObject;
            bonusObj.transform.SetParent(transform);
            bonusObj.transform.localScale = Vector3.one;
            bonusObj.GetComponent<RectTransform>().anchoredPosition =
                BlockController.BlockPositionFromSavedPosition(new Vector2(block.X, block.Y));
            bonusObj.SetActive(false);
            return bonusObj.GetComponent<CollectableBonus>();
        }
    }
}
