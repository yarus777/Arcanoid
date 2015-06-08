namespace Assets.Editor.Tabs {
    abstract class Tab {
        public string Title { get; private set; }

        protected Tab(string title) {
            Title = title;
        }

        public abstract void Draw();
    }
}
