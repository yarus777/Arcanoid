using Assets.Scripts.Game.Consts;

namespace Assets.Scripts.Engine.Moving {
    class HorizontalMovingObject : MovingObject {
        protected override GameConsts.Direction[] Directions {
            get {
                return new[] { GameConsts.Direction.Left, GameConsts.Direction.Right };
            }
        }
    }
}
