using System;
using Assets.Scripts.Game.Consts;
using UnityEngine;

namespace Assets.Scripts.Game.Parameters {
    [Serializable]
    class GameParameters {
        public Vector2 BallSpeed;
        public GameConsts.FieldType FieldType;
        public int BlockCount;
        public int GridSizeX;
        public int GridSizeY;
        public Vector2 BlockSize;
    }
}
