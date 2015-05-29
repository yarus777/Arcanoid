using Assets.Scripts.Engine.Striked;

using UnityEngine;

namespace Assets.Scripts.Game.State.FailReasons {
    class LoseBallBorder : MonoBehaviour, IFailReason {
        #region Events

        public event FailReasonDelegate Failed;

        private void OnFail() {
            var handler = Failed;
            if (handler != null) {
                handler();
            }
            Time.timeScale = 0;
        }

        #endregion

        private void OnTriggerEnter2D(Collider2D coll) {
            if (coll.GetComponent(typeof(IStriker)) != null) {
                OnFail();    
            }
        }
    }
}
