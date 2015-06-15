using Assets.Scripts.Engine.Striked;
using Assets.Scripts.Game.Bonuses.Implementations;
using Assets.Scripts.Game.Consts;
using Assets.Scripts.Serialization;
using Assets.Scripts.Serialization.Levels;

using UnityEngine;

namespace Assets.Scripts.Game.Blocks {
    [RequireComponent(typeof(BoxCollider2D))]
    abstract class Block : AbstractBlock {
        private BoxCollider2D _collider;

        private BoxCollider2D Collider {
            get {
                return _collider ?? (_collider = GetComponent<BoxCollider2D>());
            }
        }

        public abstract BlockType Type { get; }

        [SerializeField]
        private CollectableBonus _bonus;

        public void Init(BlockInfo blockInfo) {
            var rectTransform = transform as RectTransform;
            rectTransform.anchoredPosition = BlockController.BlockPositionFromSavedPosition(new Vector2(blockInfo.X, blockInfo.Y));
            rectTransform.localScale = new Vector3(1, 1, 1);
            rectTransform.sizeDelta = new Vector2(GameConsts.BLOCK_SIZE.x, GameConsts.BLOCK_SIZE.y);
            Collider.size = GameConsts.BLOCK_SIZE;
            Collider.center = new Vector2(GameConsts.BLOCK_SIZE.x / 2, -GameConsts.BLOCK_SIZE.y / 2);
            name = string.Format("{0}[{1}][{2}]", name, blockInfo.X, blockInfo.Y);
        }

        private void OnCollisionEnter2D(Collision2D collision) {
            var striker = (IStriker)collision.gameObject.GetComponent(typeof(IStriker));
            if (striker == null) {
                return;
            }
            SendBonus();
            OnStriked(striker);
        }

        private void SendBonus() {
            if (_bonus == null) {
                return;
            }
            _bonus.gameObject.SetActive(true);
            _bonus.Send();
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
