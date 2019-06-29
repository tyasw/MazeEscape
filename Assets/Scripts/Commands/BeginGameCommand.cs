using UnityEngine;
using Assets.Scripts.Events;

namespace Assets.Scripts.Commands {
    public class BeginGameCommand : Command {
        private CustomEventSystem eventSystem;

        private void Awake() {
            eventSystem = GameObject.FindObjectOfType<CustomEventSystem>();
        }

        public override void Run() {
            eventSystem.FireEvent(typeof(StartGameEvent));
        }

        public override string ToString() {
            return "BeginGameCommand";
        }
    }
}
