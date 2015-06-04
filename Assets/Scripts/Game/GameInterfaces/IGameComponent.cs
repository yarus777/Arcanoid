using Assets.Scripts.Game.Levels;

namespace Assets.Scripts.Game.GameInterfaces {
    interface IGameComponent {
        void StartGame(Level level);
        void FinishGame();
    }
}
