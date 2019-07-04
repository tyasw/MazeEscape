using UnityEngine;
using Assets.Scripts.Commands;

namespace Assets.Scripts.Events {
    /*
     * Run a command when the user presses a specified key on the keyboard.
     */
    public class KeyboardPress : MonoBehaviour {
        public KeyCode KeyCode;
        public Command Command;

        private void Awake() {
            Command = GetComponent<Command>();
        }

        private void Update() {
            if (Input.GetKeyDown(KeyCode)) {
                OnKeyDown();
            }
        }

        private void OnKeyDown() {
            Command.Run();
        }
    }
}
