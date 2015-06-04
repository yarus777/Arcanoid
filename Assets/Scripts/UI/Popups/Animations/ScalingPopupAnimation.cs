using DG.Tweening;

using UnityEngine;

namespace Assets.Scripts.UI.Popups.Animations {
    class ScalingPopupAnimation : IPopupAnimation {
        private const float DURATION = .5f;
        public void Show(RectTransform content, PopupAnimationCallback callback = null) {
            content.localScale = new Vector3(0, 0, 0);
            Animate(content, Vector2.one, Ease.OutBack, callback);
        }

        public void Close(RectTransform content, PopupAnimationCallback callback = null) {
            Animate(content, Vector2.zero, Ease.InBack, callback);
        }

        private void Animate(Transform content, Vector2 scale, Ease ease, PopupAnimationCallback callback) {
            content.DOScale(scale, DURATION).OnComplete(() => {
                if (callback != null) {
                    callback();
                }
            }
            ).SetEase(ease);
        }
    }
}
