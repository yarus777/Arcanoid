using UnityEngine;

namespace Assets.Scripts.Engine.Striked {
    public delegate void BlockStrikedDelegate(AbstractBlock striked, IStriker striker);

    public abstract class AbstractBlock : MonoBehaviour {
        public abstract event BlockStrikedDelegate Striked;
    }
}
