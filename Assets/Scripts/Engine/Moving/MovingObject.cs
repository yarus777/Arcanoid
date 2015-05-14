using Assets.Scripts.Engine.Input;
using Assets.Scripts.Game.Consts;

using UnityEngine;

namespace Assets.Scripts.Engine.Moving {
    abstract class MovingObject : MonoBehaviour {
        protected abstract GameConsts.Direction[] Directions { get; }

        private IInputController _inputController;

        public void Init(IInputController inputController) {
            _inputController = inputController;
        }
    }
}
