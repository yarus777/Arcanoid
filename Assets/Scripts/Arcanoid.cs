using Assets.Scripts.Game.Parameters;
using Assets.Scripts.Game.Parameters.Handlers;

namespace Assets.Scripts {
    class Arcanoid {
        #region Singleton

        private static Arcanoid _instance;

        public static Arcanoid Instance {
            get {
                return _instance ?? new Arcanoid();
            }
        }

        #endregion

        public void Init() {
        }

        public Arcanoid() {
            Initialize();
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
        }
    }
}
