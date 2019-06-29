using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Events;

namespace Assets.Scripts.Commands {
    public class ShowNewGameOptionsCommand : Command {
        private CustomEventSystem eventSystem;

        private void Awake() {
            eventSystem = GameObject.FindObjectOfType<CustomEventSystem>();
        }

        public override void Run() {
            eventSystem.FireEvent(typeof(ShowGameOptionsEvent));
        }

        public override string ToString() {
            return "ShowNewGameOptionsCommand";
        }
    }
}
