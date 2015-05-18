using Assets.Scripts.Engine.Striked;
using Assets.Scripts.Game.Balls;
using Assets.Scripts.Game.GameInterfaces;

using UnityEngine;

namespace Assets.Scripts.Game.Blocks {
    class BlockController : MonoBehaviour, IGameComponent, IInitializable {
        public void Init() {
            foreach (var block in GetComponentsInChildren<Block>()) {
                block.Striked += OnBlockStriked;
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
