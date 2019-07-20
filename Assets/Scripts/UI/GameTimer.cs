using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI {
    /*
     * Controls the timer that runs while the player traverses the maze. It should
     * be attached to the same object that the UIManager is attached to.
     */
    public class GameTimer : MonoBehaviour {
        public Text GameTimeText;
        public float elapsedTime;

        private void Awake() {
            GameTimeText = GetComponent<Text>();
        }

        private void Start() {
            elapsedTime = 0.0f;
            GameTimeText.text = " ";
        }

        private void Update() {
            elapsedTime += Time.deltaTime;
            GameTimeText.text = "Time: " + elapsedTime.ToString("f2");
        }
    }
}
