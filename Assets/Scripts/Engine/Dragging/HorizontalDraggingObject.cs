using Assets.Scripts.Game.Consts;

namespace Assets.Scripts.Engine.Dragging {
    class HorizontalDraggingObject : DraggingObject {
        protected override GameConsts.Direction[] Directions {
            get {
                return new[] { GameConsts.Direction.Horizontal };
            }
        }
    }
}
