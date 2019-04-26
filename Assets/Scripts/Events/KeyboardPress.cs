using UnityEngine;
using Assets.Scripts.Commands;

namespace Assets.Scripts.Events {
    public class KeyboardPress : MonoBehaviour {
        public KeyCode KeyCode;
        public CommandParser CommandParser;
        public Command Command;

        private void Start() {
            CommandParser = CommandParser.GetInstance();
            Command = GetComponent<Command>();  // Command should be a MonoBehaviour
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
