using Assets.Scripts.Engine.Striked;
using Assets.Scripts.Game.Blocks.Data;
using UnityEngine;

namespace Assets.Scripts.Game.Blocks {
    [RequireComponent(typeof(BoxCollider2D))]
    class Block : MonoBehaviour, IStrikedObject {
        private BoxCollider2D _collider;

        private BoxCollider2D Collider {
            get {
                return _collider ?? (_collider = GetComponent<BoxCollider2D>());
            }
        }

        public void Init(BlockInfo blockInfo) {
            var rectTransform = transform as RectTransform;
            rectTransform.anchoredPosition = new Vector2(blockInfo.XPos * blockInfo.Width, blockInfo.YPos * blockInfo.Height);
            rectTransform.localScale = new Vector3(1, 1, 1);
            rectTransform.sizeDelta = new Vector2(blockInfo.Width, blockInfo.Height);
            Collider.size = new Vector2(blockInfo.Width, blockInfo.Height);
            name = string.Format("{0}[{1}][{2}]", name, blockInfo.XPos, blockInfo.YPos);
        }

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
