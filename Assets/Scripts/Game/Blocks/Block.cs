using Assets.Scripts.Engine.Striked;

using UnityEngine;

namespace Assets.Scripts.Game.Blocks {
    class Block : MonoBehaviour, IStrikedObject {

        private void OnCollisionEnter2D(Collision2D collision) {
            var striker = (IStriker)collision.gameObject.GetComponent(typeof(IStriker));
            if (striker == null) {
                return;
            }
            OnStriked(striker);
        }

        #region Events

        public event StrikedDelegate Striked;

        private void OnStriked(IStriker striker) {
            var handler = Striked;
            if (handler != null) {
                handler(this, striker);
            }
        }

        #endregion

    }
}
