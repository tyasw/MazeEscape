using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts.Commands;

namespace Assets.Scripts.Events {
    public class ButtonClick : MonoBehaviour {
        public Button Button;
        public CommandParser CommandParser;
        public Command Command;

        private void Start() {
            ClassFactory classFactory = ClassFactory.GetInstance();
            CommandParser = classFactory.GetCommandParser();
            Command = GetComponent<Command>();
            Button.onClick.AddListener(OnClick);
        }

        private void OnClick() {
            CommandParser.AddCommand(Command);
            CommandParser.RunNextCommand();
        }
    }
}
