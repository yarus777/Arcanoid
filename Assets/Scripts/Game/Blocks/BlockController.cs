using Assets.Scripts.Engine.Striked;
using Assets.Scripts.Game.Blocks.Creators;
using Assets.Scripts.Game.GameInterfaces;
using System.Collections.Generic;

using Assets.Scripts.Engine.Extensions;
using Assets.Scripts.Game.Levels;

using UnityEngine;

namespace Assets.Scripts.Game.Blocks {
    class BlockController : MonoBehaviour, IGameComponent {
        [SerializeField]
        private Block[] BlocksPrefabs;

        private List<Block> _blocks = new List<Block>();

        public void Init(BlockCreator creator) {
            foreach(var blockInfo in creator.BlocksInfo) {
                var blockObj = Instantiate(BlocksPrefabs.Random().gameObject) as GameObject;
                blockObj.transform.SetParent(transform);
                var block = blockObj.GetComponent<Block>();
                block.Init(blockInfo);
                block.Striked += OnBlockStriked;
                _blocks.Add(block);
            }
        }
        
        public void StartGame(Level level) {
            
        }

        public void FinishGame() {
        }

        private void OnBlockStriked(IStrikedObject striked, IStriker striker) {
            //todo не использовать напрямую block, использовать интерфейс
            Destroy(((Block)striked).gameObject);
        }

    }
}
