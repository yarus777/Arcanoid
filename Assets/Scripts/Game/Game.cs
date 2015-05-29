using Assets.Scripts.Engine;
using Assets.Scripts.Game.Balls;
using Assets.Scripts.Game.Blocks;
using Assets.Scripts.Game.Blocks.Creators;
using Assets.Scripts.Game.Consts;
using Assets.Scripts.Game.GameInterfaces;
using Assets.Scripts.Game.Parameters;
using UnityEngine;

namespace Assets.Scripts.Game {
    class Game : MonoBehaviour {
        #region Singleton

        public static Game Instance { get; private set; }

        private void Awake() {
            Instance = this;
            Init();
            StartGame();
        }

        #endregion

        #region Editor fields

        [SerializeField]
        private BlockController BlockController;

        [SerializeField]
        private BallController BallController;

        [SerializeField]
        private GameParameters Parameters;

        #endregion

        private readonly ObjectStorage _storage = new ObjectStorage();

        #region Initializing

        private void Init() {
            InitBalls();
            InitBlocks();

            InitComponents();
        }

        private void InitBalls() {
            BallController.Init(Parameters.BallSpeed);
            _storage.Add(BallController);
        }

        private void InitBlocks() {
            BlockCreator blockCreator;
            if (Parameters.FieldType == GameConsts.FieldType.Random) {
                blockCreator = new RandomBlockCreator(Parameters.BlockCount, Parameters.BlockSize.x, Parameters.BlockSize.y, Parameters.GridSizeX, Parameters.GridSizeY);
            }
            else {
                blockCreator = new RestoringBlockCreator();
            }
            BlockController.Init(blockCreator);
            _storage.Add(BlockController);
        }

        #endregion

        #region Game state

        private void InitComponents() {
            foreach (var component in _storage.Get<IInitializable>()) {
                component.Init();
            }
        }

        private void StartGame() {
            foreach (var component in _storage.Get<IGameComponent>()) {
                component.StartGame();
            }
        }

        private void FinishGame() {
            foreach (var component in _storage.Get<IGameComponent>()) {
                component.FinishGame();
            }
        }

        #endregion

    }
}
