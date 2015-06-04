using Assets.Scripts.Engine;
using Assets.Scripts.Engine.State;
using Assets.Scripts.Engine.State.Serializers;
using Assets.Scripts.Engine.State.StateSavers;
using Assets.Scripts.Engine.Subscription;
using Assets.Scripts.Game.Parameters;
using Assets.Scripts.Game.Parameters.Handlers;
using Assets.Scripts.Parameters;
using Assets.Scripts.Serialization.Parameters;

namespace Assets.Scripts {
    class Arcanoid : UnitySingleton<Arcanoid> {
        private readonly ObjectStorage _storage = new ObjectStorage();

        protected override void LateAwake() {
            Initialize();
            InitStateChangable();
            Load(Tools.StateSerializer);
            Subscribe();
        }

        private void OnDestroy() {
            Unsubscribe();
            Uninitialize();
        }

        #region Game items

        public Statistics Statistics { get; private set; }
        public DefaultParameters DefaultParameters { get; private set; }

        #endregion
        

        private void Initialize() {
            InitDefaults();
            InitStatistics();
        }

        private void Uninitialize() {
            foreach (var item in _storage.Get<IUninitialize>()) {
                item.DeInit();
            }
        }

        private void InitStatistics() {
            Statistics = new Statistics(Tools.StateSerializer);
            Statistics.RegisterItem(new LivesHandler());
            Statistics.RegisterItem(new ScoreHandler());

            _storage.Add(Statistics);
        }

        private void InitDefaults() {
            DefaultParameters = DefaultParameters.Load(new XmlSerializer(new ResourceStateSaver()));
        }

        #region Save State

        public void InitStateChangable() {
            foreach (var item in _storage.Get<ISaveLoadState>()) {
                item.StateChanged += Save;
            }
        }

        public void Load(IStateSerializer stateSerializer) {
            foreach (var item in _storage.Get<ILoadState>()) {
                item.Load(stateSerializer);
            }
        }

        public void Save(IStateSerializer stateSerializer) {
            foreach (var item in _storage.Get<ISaveLoadState>()) {
                item.Save(stateSerializer);
            }
        }

        private void Save(ISaveLoadState item) {
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
