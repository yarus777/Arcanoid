using Assets.Scripts.UI.Popups.Animations;

using UnityEngine;

namespace Assets.Scripts.UI.Popups {
    abstract class Popup : MonoBehaviour {
        [SerializeField]
        private RectTransform Content;

        public void Show(IPopupAnimation animator) {
            animator.Show(Content, OnShow);
        }

        public void Close(IPopupAnimation animator) {
            animator.Close(Content, OnClose);
        }

        protected virtual void OnShow() {
            
        }

        protected virtual void OnClose() {
            Game.Game.Instance.UI.Popups.RemoveTop();
        }

        public void Close() {
            Game.Game.Instance.UI.Popups.Close();
        }

        public void OnClick() {
            Close();
        }
    }
}
