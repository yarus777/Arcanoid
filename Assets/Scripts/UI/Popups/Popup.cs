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
            PopupController.Instance.RemoveTop();
        }

        public void Close() {
            PopupController.Instance.Close();
        }

        public void OnClick() {
            Close();
        }
    }
}
