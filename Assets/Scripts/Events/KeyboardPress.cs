using UnityEngine;
using Assets.Scripts.Commands;

namespace Assets.Scripts.Events {
    /*
     * Run a command when the user presses a specified key on the keyboard.
     */
    public class KeyboardPress : MonoBehaviour {
        public KeyCode KeyCode;
        public CommandParser CommandParser;
        public Command Command;

        private void Awake() {
            CommandParser = GameObject.FindObjectOfType<CommandParser>();
            Command = GetComponent<Command>();
        }

        private void Update() {
            if (Input.GetKeyDown(KeyCode)) {
                OnKeyDown();
            }
        }

        private void OnKeyDown() {
            CommandParser.AddCommand(Command);
            CommandParser.RunNextCommand();
        }
    }
}
