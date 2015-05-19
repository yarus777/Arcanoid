using Assets.Scripts.Engine.Striked;
using Assets.Scripts.Game.Blocks.Creators;
using Assets.Scripts.Game.GameInterfaces;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Game.Blocks {
    class BlockController : MonoBehaviour, IGameComponent {
        private List<Block> _blocks = new List<Block>();

        public void Init(BlockCreator creator) {
            //foreach (var block in GetComponentsInChildren<Block>()) {
            foreach(var blockInfo in creator.BlocksInfo) {
                var blockObj = Instantiate(Resources.Load("Block")) as GameObject;
                blockObj.transform.SetParent(transform);
                var block = blockObj.GetComponent<Block>();
                block.Init(blockInfo);
                block.Striked += OnBlockStriked;
                _blocks.Add(block);
            }
        }
        
        public void StartGame() {
            
        }

        public void FinishGame() {
        }

        private void OnBlockStriked(IStrikedObject striked, IStriker striker) {
            //todo не использовать напрямую block, использовать интерфейс
            Destroy(((Block)striked).gameObject);
        }

    }
}
