using UnityEngine;

namespace Assets.Scripts.UI.MapScene {
    class LevelController : MonoBehaviour {
        [SerializeField]
        private int MaxLevelNumber;

        [SerializeField]
        private int LevelInRow;

        [SerializeField]
        private LevelPreview LevelPrefab;

        private void Start() {
            int row = 0;
            int col = 0;
            for (var i = 0; i <= MaxLevelNumber; i++) {
                var obj = Instantiate(LevelPrefab.gameObject) as GameObject;
                obj.transform.parent = transform;
                obj.transform.localPosition = new Vector2(col * LevelPreview.WIDTH, row * LevelPreview.HEIGHT);
                obj.transform.localScale = Vector3.one;
                col++;
                if (col >= LevelInRow) {
                    row++;
                    col = 0;
                }
                var lvl = obj.GetComponent<LevelPreview>();
                lvl.Number = i;
            }
        }
    }
}
