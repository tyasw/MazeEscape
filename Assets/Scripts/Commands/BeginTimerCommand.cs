using System.Collections.Generic;
using Assets.Scripts.Events;
using UnityEngine;

namespace Assets.Scripts.Commands {
    public class BeginTimerCommand : Command {
        private CustomEventSystem eventSystem;

        private void Awake() {
            eventSystem = GameObject.FindObjectOfType<CustomEventSystem>();
        }

        public override void Run() {
            eventSystem.FireEvent(typeof(MazeStartedEvent));
        }

        public override string ToString() {
            return "BeginTimerCommand";
        }
    }
}
