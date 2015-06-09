using Assets.Scripts;
using Assets.Scripts.Engine;
using Assets.Scripts.Game.Balls;
using Assets.Scripts.Game.Blocks;
using Assets.Scripts.Game.Blocks.Creators;
using Assets.Scripts.Game.Bounds;
using Assets.Scripts.Game.Consts;
using Assets.Scripts.Game.GameInterfaces;
using Assets.Scripts.Game.Levels;
using Assets.Scripts.Game.Parameters;
using Assets.Scripts.Game.State;
using Assets.Scripts.Game.State.FailReasons;
using Assets.Scripts.UI.GameScene;
using Assets.Scripts.UI.Popups.Implementations;

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

        private void OnDestroy() {
            foreach (var obj in _storage.Get<IUninitialize>()) {
                obj.DeInit();
            }
        }

        #endregion

        #region Editor fields

        [SerializeField]
        private BlockController BlockController;

        [SerializeField]
        private BallController BallController;

        [SerializeField]
        private Ground BottomBorder;

        [SerializeField]
        private GameParameters Parameters;

        [SerializeField]
        private GameUIController UIController;

        #endregion

        private readonly ObjectStorage _storage = new ObjectStorage();

        #region Public properties

        public StateController State {
            get {
                return _storage.GetFirst<StateController>();
            }
        }

        public BlockController Blocks {
            get {
                return _storage.GetFirst<BlockController>();
            }
        }

        public GameUIController UI {
            get {
                return UIController;
            }
        }

        public Ground Ground {
            get {
                return _storage.GetFirst<Ground>();
            }
        }

        #endregion

        #region Initializing

        private void Init() {
            InitBalls();
            InitBlocks();

            InitComponents();
            InitStateController();
            InitBounds();
        }

        private void InitBalls() {
            BallController.Init(Parameters.BallSpeed);
            _storage.Add(BallController);
        }

        private void InitBlocks() {
            var currentLevel = Arcanoid.Instance.LevelStorage.CurrentLevel;
            BlockController.Init(currentLevel.BlockCreator);
            _storage.Add(BlockController);
        }

        private void InitStateController() {
            _storage.Add(Arcanoid.Instance.StateController);
        }

        private void InitBounds() {
            _storage.Add(BottomBorder);
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
                component.StartGame(Arcanoid.Instance.LevelStorage[0]);
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
