using System.Collections.Generic;
using System.Linq;

using Assets.Scripts.UI.Popups.Animations;

using UnityEngine;

namespace Assets.Scripts.UI.Popups {
    class PopupController : MonoBehaviour {
        [SerializeField]
        private Popup[] PopupsPrefabs;

        private readonly Stack<Popup> _popups = new Stack<Popup>();
        private IPopupAnimation _animator = new ScalingPopupAnimation();

        public void ShowPopup<T>() where T: Popup{
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
