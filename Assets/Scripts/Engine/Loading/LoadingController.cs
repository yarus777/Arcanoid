namespace Assets.Scripts.Engine.Loading {
    class LoadingController {
        #region Singleton

        private static LoadingController instance;

        public static LoadingController Instance {
            get {
                return instance ?? (instance = new LoadingController());
            }
        }

        #endregion

        #region Loaders

        public SceneLoader SceneLoader { get; private set; }

        #endregion

        private LoadingController() {
            SceneLoader = new SceneLoader();
        }
    }
}
