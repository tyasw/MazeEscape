﻿using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts.Commands;

namespace Assets.Scripts.Events {
    /*
     * Run a command when the user clicks on a specified button.
     */
    public class ButtonClick : MonoBehaviour {
        public Button Button;
        public CommandParser CommandParser;
        public Command Command;

        private void Awake() {
            CommandParser = GameObject.FindObjectOfType<CommandParser>();
            Command = GetComponent<Command>();
        }

        private void Start() {
            Button.onClick.AddListener(OnClick);
        }

        private void OnClick() {
            CommandParser.AddCommand(Command);
            CommandParser.RunNextCommand();
        }
    }
}
