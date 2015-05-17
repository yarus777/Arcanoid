using UnityEngine;

namespace Assets.Scripts.Engine.Striked {
    public delegate void StrikedDelegate(Transform striked, Transform striker);
    interface IStrikedObject {
        event StrikedDelegate Striked;

    }
}
