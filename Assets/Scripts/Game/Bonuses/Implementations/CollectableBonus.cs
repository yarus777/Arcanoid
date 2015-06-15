using Assets.Scripts.Game.Bonuses.Collectors;
using Assets.Scripts.Serialization;

using UnityEngine;

namespace Assets.Scripts.Game.Bonuses.Implementations {
    [RequireComponent(typeof(Collider2D))]
    [RequireComponent(typeof(Rigidbody2D))]
    abstract class CollectableBonus : MonoBehaviour, IBonus {
        public abstract void Apply();

        public virtual void Lose() {
            Remove();
        }

        public abstract BonusType Type { get; }

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

        public void Send() {
            rigidbody2D.AddForce(new Vector2(0, -1500));
        }
    }
}
