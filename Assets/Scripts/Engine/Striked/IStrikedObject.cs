using UnityEngine;

namespace Assets.Scripts.Engine.Striked {
    public delegate void StrikedDelegate(IStrikedObject striked, IStriker striker);

    public interface IStrikedObject {
        event StrikedDelegate Striked;

    }
}
