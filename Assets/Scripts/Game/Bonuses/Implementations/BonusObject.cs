using UnityEngine;

namespace Assets.Scripts.Game.Bonuses.Implementations {
    abstract class BonusObject : MonoBehaviour, IBonus {
        public abstract void Apply();

        public virtual void Lose() {
            Remove();
        }

        protected virtual void Remove() {
            Destroy(gameObject);
        }
    }
}
