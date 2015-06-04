using UnityEngine;

namespace Assets.Scripts.UI.Popups.Animations {
    public delegate void PopupAnimationCallback();
    interface IPopupAnimation {
        void Show(RectTransform content, PopupAnimationCallback callback = null);
        void Close(RectTransform content, PopupAnimationCallback callback = null);
    }
}
