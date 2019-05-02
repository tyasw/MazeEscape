using UnityEngine;
using Assets.Scripts.Commands;

namespace Assets.Scripts.Events {
    public class KeyboardPress : MonoBehaviour {
        public KeyCode KeyCode;
        public CommandParser CommandParser;
        public Command Command;

        private void Start() {
            ClassFactory classFactory = ClassFactory.GetInstance();
            CommandParser = classFactory.GetCommandParser();
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
