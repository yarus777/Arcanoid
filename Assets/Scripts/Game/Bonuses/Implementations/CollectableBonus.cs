using Assets.Scripts.Game.Bonuses.Collectors;

using UnityEngine;

namespace Assets.Scripts.Game.Bonuses.Implementations {
    [RequireComponent(typeof(Collider2D))]
    abstract class CollectableBonus : MonoBehaviour, IBonus {
        public abstract void Apply();

        public virtual void Lose() {
            Remove();
        }

        protected virtual void Remove() {
            Destroy(gameObject);
        }

        private void OnTriggerEnter2D(Collider2D collision) {
            var collector = (IBonusCollector)collision.gameObject.GetComponent(typeof(IBonusCollector));
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
