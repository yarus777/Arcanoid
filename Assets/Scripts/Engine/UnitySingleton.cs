using UnityEngine;

namespace Assets.Scripts.Engine {

    public class UnitySingleton<T> : MonoBehaviour
        where T : MonoBehaviour {

        private static T instance;
        private static object lockObject = new object();

        public static T Instance {
            get {
                if (instance == null) {
                    lock (lockObject) {
                        instance = FindObjectOfType<T>();
                        if (instance == null) {
                            var gameObject = new GameObject("[" + typeof(T).Name + "]");
                            instance = gameObject.AddComponent<T>();
                        }
                    }
                }

                return instance;
            }
        }

        private void Awake() {
            if (instance && instance.gameObject != gameObject) {
                DestroyImmediate(gameObject);
            }
            else {
                instance = GetComponent<T>();
                DontDestroyOnLoad(gameObject);
                LateAwake();
            }
        }

        protected virtual void LateAwake() {
        }

        public virtual void Init() {
        }
    }
}