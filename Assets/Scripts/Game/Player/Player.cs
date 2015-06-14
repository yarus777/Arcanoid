using DG.Tweening;
using UnityEngine;

namespace Assets.Scripts.Game.Player {
    public class Player : MonoBehaviour {
        public const float SIZE_DELTA = 50;
        public const float MAX_SIZE = 300;

        private RectTransform _transform;

        private RectTransform Transform {
            get { return _transform ?? (_transform = GetComponent<RectTransform>()); }
        }

        public void Increase() {
            var size = Transform.sizeDelta + new Vector2(SIZE_DELTA, 0);
            if (size.x > MAX_SIZE) {
                return;
            }
            Transform.DOSizeDelta(size, 0.7f);
        }
    }
}
