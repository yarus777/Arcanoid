using System.Collections.Generic;
using System.Linq;

using Assets.Scripts.Engine.Striked;
using Assets.Scripts.Game.Blocks.Creators;
using Assets.Scripts.Game.GameInterfaces;
using Assets.Scripts.Game.Levels;
using Assets.Scripts.Serialization.Levels;

using UnityEngine;

namespace Assets.Scripts.Game.Blocks {
    class BlockController : MonoBehaviour, IGameComponent {
        [SerializeField]
        private Block[] BlocksPrefabs;

        private readonly List<AbstractBlock> _blocks = new List<AbstractBlock>();

        public void StartGame(Level level) {
            foreach (var blockInfo in level.Blocks) {
                var prefab = BlocksPrefabs.FirstOrDefault(x => x.Type == blockInfo.Type);
                if (prefab == null) {
                    continue;
                }
                var blockObj = Instantiate(prefab.gameObject) as GameObject;
                blockObj.transform.SetParent(transform);
                var block = blockObj.GetComponent<Block>();
                block.Init(blockInfo);
                block.Striked += OnBlockStriked;
                _blocks.Add(block);
            }
        }

        public void FinishGame() {
        }

        private void OnBlockStriked(AbstractBlock block, IStriker striker) {
            _blocks.Remove(block);
            Destroy(block.gameObject);
            OnBlockCountChanged();
        }

        #region Events

        public delegate void BlockCountChangedDelegate(int blocksLeft);
        public event BlockCountChangedDelegate BlockCountChanged;

        private void OnBlockCountChanged() {
            var handler = BlockCountChanged;
            if (handler != null) {
                handler.Invoke(_blocks.Count);
            }
        }

        #endregion

    }
}
