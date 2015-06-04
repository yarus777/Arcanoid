using System;

using UnityEngine;

namespace Assets.Scripts.Engine.Tools {
    [Flags]
    public enum Direction {
        Vertical = 1,
        Horizontal = 2
    }

    [RequireComponent(typeof(BoxCollider2D))]
    class ColliderScaler : MonoBehaviour {
        [SerializeField]
        private Direction Direction;

        private void Awake() {
            var collider = GetComponent<BoxCollider2D>();
            if ((Direction & Direction.Vertical) == Direction.Vertical) {
                //collider.bounds.size.Set();
            }
        }
    }
}
