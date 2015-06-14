using Assets.Scripts.Engine;
using Assets.Scripts.Game.Balls;
using Assets.Scripts.Game.Blocks;
using Assets.Scripts.Game.Bonuses;
using Assets.Scripts.Game.Bounds;
using Assets.Scripts.Game.GameInterfaces;
using Assets.Scripts.Game.Parameters;
using Assets.Scripts.Game.Player;
using Assets.Scripts.Game.State;
using Assets.Scripts.UI.GameScene;

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
        private BonusController BonusController;

        [SerializeField]
        private BallController BallController;

        [SerializeField]
        private PlayerController PlayerController;

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

        public PlayerController Player {
            get { return _storage.GetFirst<PlayerController>(); }
        }

        #endregion

        #region Initializing

        private void Init() {
            InitBalls();
            InitBlocks();
            InitBonuses();
            InitPlayer();

            InitComponents();
            InitStateController();
            InitBounds();
        }

        private void InitBalls() {
            BallController.Init(Arcanoid.Instance.DefaultParameters.LivesCount, Parameters.BallSpeed, PlayerController.Platform);
            _storage.Add(BallController);
        }

        private void InitBlocks() {
            //var currentLevel = Arcanoid.Instance.LevelStorage.CurrentLevel;
            //BlockController.Init(currentLevel.Blocks);
            _storage.Add(BlockController);
        }

        private void InitBonuses() {
            _storage.Add(BonusController);
        }

        private void InitPlayer() {
            _storage.Add(PlayerController);
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
            var currentLevel = Arcanoid.Instance.LevelStorage.CurrentLevel;
            foreach (var component in _storage.Get<IGameComponent>()) {
                component.StartGame(currentLevel);
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
