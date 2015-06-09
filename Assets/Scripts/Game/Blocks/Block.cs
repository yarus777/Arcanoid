using Assets.Scripts.Engine.Striked;
using Assets.Scripts.Game.Consts;
using Assets.Scripts.Serialization.Levels;
using UnityEngine;

namespace Assets.Scripts.Game.Blocks {
    [RequireComponent(typeof(BoxCollider2D))]
    class Block : AbstractBlock {
        private BoxCollider2D _collider;

        private BoxCollider2D Collider {
            get {
                return _collider ?? (_collider = GetComponent<BoxCollider2D>());
            }
        }

        public void Init(BlockInfo blockInfo) {
            var rectTransform = transform as RectTransform;
            rectTransform.anchoredPosition = new Vector2(blockInfo.Position.x, blockInfo.Position.y);
            rectTransform.localScale = new Vector3(1, 1, 1);
            rectTransform.sizeDelta = new Vector2(GameConsts.BLOCK_SIZE.x, GameConsts.BLOCK_SIZE.y);
            Collider.size = new Vector2(GameConsts.BLOCK_SIZE.x, GameConsts.BLOCK_SIZE.y);
            name = string.Format("{0}[{1}][{2}]", name, blockInfo.Position.x, blockInfo.Position.y);
        }

        private void OnCollisionEnter2D(Collision2D collision) {
            var striker = (IStriker)collision.gameObject.GetComponent(typeof(IStriker));
            if (striker == null) {
                return;
            }
            OnStriked(striker);
        }

        #region Events

        public override event BlockStrikedDelegate Striked;

        private void OnStriked(IStriker striker) {
            var handler = Striked;
            if (handler != null) {
                handler(this, striker);
            }
        }

        #endregion

        
    }
}
