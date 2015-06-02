using System;
using System.Collections.Generic;
using System.Linq;

using Assets.Scripts.Engine.State;
using Assets.Scripts.Engine.State.Serializers;
using Assets.Scripts.Game.Consts;
using Assets.Scripts.Game.Parameters.Handlers;
using Assets.Scripts.Serialization.Statistics;

namespace Assets.Scripts.Game.Parameters {
    class Statistics : ISaveState {
        private const string KEY = "statistics";
        private List<IStatisticHandler> _items;

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

        #region ISaveState

        public void Load(IStateSerializer stateSerializer) {
            _items = stateSerializer.Deserialize<List<IStatisticHandler>>(KEY);
        }

        public void Save(IStateSerializer stateSerializer) {
            //var saved = _items.Select(item => new SavedStatistics { Type = item.Type, Count = item.Count });
            stateSerializer.Serialize(KEY, _items);
        }

        public event StateChangedDelegate StateChanged;

        private void OnStateChanged() {
            var handler = StateChanged;
            if (handler != null) {
                handler.Invoke(this);
            }
        }

        #endregion
    }
}
