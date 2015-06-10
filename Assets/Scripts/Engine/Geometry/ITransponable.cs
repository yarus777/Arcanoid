namespace Assets.Scripts.Engine.Geometry {
    interface ITransponable {
        void Transpone(int byX, int byY);
        int X { get; }
        int Y { get; }

    }
}
