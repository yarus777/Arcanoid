using UnityEngine;

namespace Assets.Scripts.Engine.Tools {
    static class Console {
        public static void LogError(string msg) {
            Log(msg, "red");
        }

        public static void LogInfo(string msg) {
            Log(msg, "blue");
        }

        public static void LogSuccess(string msg) {
            Log(msg, "green");
        }

        private static void Log(string msg, string color) {
            Debug.Log(string.Format("<color={0}>{1}</color>", color, msg));
        }
    }
}
