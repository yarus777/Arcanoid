using System;
using System.Collections.Generic;
using System.Linq;

using Assets.Scripts.Game.Consts;
using Assets.Scripts.Game.Parameters.Handlers;

namespace Assets.Scripts.Game.Parameters {
    class Statistics {
        private readonly List<IStatisticHandler> _items;

        public Statistics() {
            _items = new List<IStatisticHandler>();
        }

        public IStatisticHandler Get(GameConsts.StatisticItems type) {
            return _items.FirstOrDefault(item => item.Type == type);
        }

        public bool RegisterItem(IStatisticHandler item) {
            if (_items.Any(it => it.Type == item.Type)) {
                return false;
            }
            _items.Add(item);
            return true;
        }

        public int GetValue(GameConsts.StatisticItems type) {
            var handler = _items.FirstOrDefault(x => x.Type == type);
            if (handler == null) {
                throw new ArgumentException("Unknown handler type");
            }
            return handler.Count;
        }
    }
}
