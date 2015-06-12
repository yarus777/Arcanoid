using System.Collections.Generic;
using System.Linq;

using Assets.Scripts.Engine;
using Assets.Scripts.Game.State;
using Assets.Scripts.UI.Popups.Animations;
using Assets.Scripts.UI.Popups.Implementations;

using UnityEngine;

namespace Assets.Scripts.UI.Popups {
    class PopupController : UnitySingleton<PopupController> {
        [SerializeField]
        private Popup[] PopupsPrefabs;

        private readonly Stack<Popup> _popups = new Stack<Popup>();
        private IPopupAnimation _animator = new ScalingPopupAnimation();

        private Arcanoid _arcanoid;

        private void Start() {
            _arcanoid = Arcanoid.Instance;
            _arcanoid.StateController.StateChanged += OnStateChanged;
        }

        private void OnDestroy() {
            _arcanoid.StateController.StateChanged -= OnStateChanged;
        }

        #region Event handlers

        private void OnStateChanged(GameState state) {
            switch (state) {
                case GameState.Win:
                    ShowPopup<WinPopup>();
                    break;
                case GameState.Lose:
                    ShowPopup<LosePopup>();
                    break;
            }
        }

        #endregion

        public void ShowPopup<T>() where T : Popup {
            var popup = PopupsPrefabs.OfType<T>().FirstOrDefault();
            if (popup != null) {
                var newObj = Instantiate(popup.gameObject) as GameObject;
                newObj.transform.SetParent(transform, false);
                newObj.transform.localPosition = Vector3.zero;
                var popupComp = newObj.GetComponent<Popup>();
                _popups.Push(popupComp);
                popupComp.Show(_animator);
            }
        }

        public void Close() {
            if (_popups.Count == 0) {
                return;
            }

            var popup = _popups.Peek();
            popup.Close(_animator);
        }

        public void RemoveTop() {
            if (_popups.Count == 0) {
                return;
            }

            var popup = _popups.Pop();
            DestroyImmediate(popup.gameObject);
        }
    }
}
