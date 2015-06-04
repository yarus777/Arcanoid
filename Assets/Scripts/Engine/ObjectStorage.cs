using System;
using System.Collections.Generic;
using System.Linq;

namespace Assets.Scripts.Engine {
    class ObjectStorage {
        private List<Object> _objects = new List<object>();

        public void Add(Object obj) {
            _objects.Add(obj);
        }

        public IEnumerable<T> Get<T>() {
            return _objects.OfType<T>();
        }

        public T GetFirst<T>() {
            return _objects.OfType<T>().FirstOrDefault();
        }
    }
}
