using System;
using System.Collections.Generic;
using System.Linq;

using Assets.Scripts.Engine;
using Assets.Scripts.Engine.State;
using Assets.Scripts.Engine.State.Serializers;
using Assets.Scripts.Game.Consts;
using Assets.Scripts.Game.Parameters.Handlers;

namespace Assets.Scripts.Game.Parameters {
    class Statistics : ILoadState, IUninitialize {
        private readonly List<IStatisticHandler> _items;

        private readonly IStateSerializer _stateSerializer;

        public Statistics(IStateSerializer stateSerializer) {
            _items = new List<IStatisticHandler>();
            _stateSerializer = stateSerializer;
        }

        public IStatisticHandler Get(GameConsts.StatisticItems type) {
            return _items.FirstOrDefault(item => item.Type == type);
        }

        public bool RegisterItem(IStatisticHandler item) {
            if (_items.Any(it => it.Type == item.Type)) {
                return false;
            }
            item.StateChanged += OnItemStateChanged;
            _items.Add(item);
            return true;
        }

        private void OnItemStateChanged(ISaveLoadState saveState) {
            saveState.Save(_stateSerializer);
        }

        #region ILoadState

        public void Load(IStateSerializer stateSerializer) {
            foreach (var item in _items) {
                item.Load(_stateSerializer);
            }
        }

        #endregion

        public void DeInit() {
            foreach (var item in _items) {
                item.StateChanged -= OnItemStateChanged;
            }
        }
    }
}
