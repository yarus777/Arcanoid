using Assets.Scripts.Game.Bonuses.Collectors;

using UnityEngine;

namespace Assets.Scripts.Game.Bonuses.Implementations {
    [RequireComponent(typeof(Collider2D))]
    abstract class CollectableBonus : BonusObject {
        private void OnCollisionEnter2D(Collision2D collision) {
            IBonusCollector collector = (IBonusCollector)collision.gameObject.GetComponent(typeof(IBonusCollector));
            if (collector == null) {
                return;
            }
            if (collector.IsCollectable) {
                Apply();
                Remove();
            }
            else {
                Lose();
            }
        }
    }
}
