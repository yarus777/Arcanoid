using System;

namespace Assets.Scripts.Engine.Exceptions {
    public class NotSavedException : Exception {
        public NotSavedException(string key) : base("Key[" + key + "] not found") {
        }
    }
}
