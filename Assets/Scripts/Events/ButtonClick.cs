using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts.Commands;

namespace Assets.Scripts.Events {
    public class ButtonClick : MonoBehaviour {
        public Button Button;
        public CommandParser CommandParser;
        public Command Command;

        private void Start() {
            CommandParser = CommandParser.GetInstance();
            Command = GetComponent<Command>();  // Command should be a MonoBehaviour
            Button.onClick.AddListener(OnClick);
        }

        private void OnClick() {
            CommandParser.AddCommand(Command);
            CommandParser.RunNextCommand();
        }
    }
}
