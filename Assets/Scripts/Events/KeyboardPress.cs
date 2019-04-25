using UnityEngine;

namespace Assets.Scripts.Events {
    public class KeyboardPress : MonoBehaviour {
        public KeyCode KeyCode;
        public GameEvent Event;
        public GameController GameController;

        private void Start() {
            GameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
            Event = GetComponent<GameEvent>();
        }

        private void Update() {
            if (Input.GetKeyDown(KeyCode)) {
                OnKeyDown();
            }
        }

        private void OnKeyDown() {
            Event.Trigger(GameController);
        }
    }
}
