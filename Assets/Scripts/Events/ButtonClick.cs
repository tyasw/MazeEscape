using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts.Commands;

namespace Assets.Scripts.Events {
    /*
     * Run a command when the user clicks on a specified button.
     */
    public class ButtonClick : MonoBehaviour {
        public Button Button;
        public Command Command;

        private void Awake() {
            Command = GetComponent<Command>();
        }

        private void Start() {
            Button.onClick.AddListener(OnClick);
        }

        private void OnClick() {
            Command.Run();
        }
    }
}
