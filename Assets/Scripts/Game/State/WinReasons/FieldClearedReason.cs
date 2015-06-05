using Assets.Scripts.Engine.Subscription;

namespace Assets.Scripts.Game.State.WinReasons {
    class FieldClearedReason : IWinReason, ISubscribable {

        #region Events

        public event WinReasonDelegate Win;

        private void OnWin() {
            var handler = Win;
            if (handler != null) {
                handler.Invoke(this);
            }
        }

        private void OnBlockCountChanged(int count) {
            if (count == 0) {
                OnWin();
            }
        }

        #endregion

        #region Subscription

        public void Subscribe() {
            Game.Instance.Blocks.BlockCountChanged += OnBlockCountChanged;
        }

        public void Unsubscribe() {
            Game.Instance.Blocks.BlockCountChanged -= OnBlockCountChanged;
        }

        #endregion
    }
}
