namespace Assets.Scripts.Game.Blocks.Data {
    class BlockInfo {
        public int XPos { get; private set; }
        public int YPos { get; private set; }
        public float Width { get; private set; }
        public float Height { get; private set; }

        public BlockInfo(int x, int y, float width, float height) {
            XPos = x;
            YPos = y;
            Width = width;
            Height = height;
        }
    }
}
