using Assets.Scripts.Engine.Striked;

namespace Assets.Scripts.Game.State.FailReasons {
    class BallLostReason : IFailReason {
        #region Events

        public event FailReasonDelegate Failed;

        private void OnFail() {
            var handler = Failed;
            if (handler != null) {
                handler.Invoke(this);
            }
        }

        private void OnBallLost(IStriker ball) {
            OnFail();
        }

        #endregion

        #region Subscription

        public void Subscribe() {
            Game.Instance.Ground.GroundCrossed += OnBallLost;
        }

        public void Unsubscribe() {
            Game.Instance.Ground.GroundCrossed -= OnBallLost;
        }

        #endregion
    }
}
