using Assets.Scripts.Game.Bonuses.Collectors;

using UnityEngine;

namespace Assets.Scripts.Game.Player {
    class BonusCollector : MonoBehaviour, IBonusCollector {
        public bool IsCollectable {
            get {
                return true;
            }
        }
    }
}
