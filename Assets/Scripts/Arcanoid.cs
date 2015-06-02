using Assets.Scripts.Engine;
using Assets.Scripts.Engine.State;
using Assets.Scripts.Engine.State.Serializers;
using Assets.Scripts.Engine.Subscription;
using Assets.Scripts.Game.Parameters;
using Assets.Scripts.Game.Parameters.Handlers;
using Assets.Scripts.Parameters;

namespace Assets.Scripts {
    class Arcanoid {
        #region Singleton

        private static Arcanoid instance;

        public static Arcanoid Instance {
            get {
                return instance ?? (instance = new Arcanoid());
            }
        }

        #endregion

        private readonly ObjectStorage _storage = new ObjectStorage();

        public void Init() {
        }

        private Arcanoid() {
            Initialize();
            InitStateChangable();
            Load(Tools.StateSerializer);
        }

        #region Game items

        public Statistics Statistics { get; private set; }

        #endregion
        

        private void Initialize() {
            InitStatistics();
        }

        private void InitStatistics() {
            Statistics = new Statistics();
            Statistics.RegisterItem(new LivesHandler());
            Statistics.RegisterItem(new ScoreHandler());

            _storage.Add(Statistics);
        }

        #region Save State

        public void InitStateChangable() {
            foreach (var item in _storage.Get<ISaveState>()) {
                item.StateChanged += Save;
            }
        }

        public void Load(IStateSerializer stateSerializer) {
            foreach (var item in _storage.Get<ISaveState>()) {
                item.Load(stateSerializer);
            }
        }

        public void Save(IStateSerializer stateSerializer) {
            foreach (var item in _storage.Get<ISaveState>()) {
                item.Save(stateSerializer);
            }
        }

        private void Save(ISaveState item) {
            item.Save(Tools.StateSerializer);
        }

        #endregion

        #region ISubscribable

        public void Subscribe() {
            foreach (var item in _storage.Get<ISubscribable>()) {
                item.Subscribe();
            }
        }

        public void Unsubscribe() {
            foreach (var item in _storage.Get<ISubscribable>()) {
                item.Unsubscribe();
            }
        }

        #endregion
    }
}
