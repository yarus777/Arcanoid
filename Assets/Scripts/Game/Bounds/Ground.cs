using Assets.Scripts.Engine.Striked;

using UnityEngine;

namespace Assets.Scripts.Game.Bounds {
    [RequireComponent(typeof(Collider2D))]
    class Ground : MonoBehaviour {
        #region Events

        public delegate void GroundCrossedDelegate(IStriker ball);
        public event GroundCrossedDelegate GroundCrossed;

        private void OnFail(IStriker ball) {
            var handler = GroundCrossed;
            if (handler != null) {
                handler(ball);
            }
        }

        #endregion

        private void OnTriggerEnter2D(Collider2D coll) {
            var comp = coll.GetComponent(typeof(IStriker)); 
            if (comp != null) {
                OnFail((IStriker)comp);
            }
        }
    }
}
