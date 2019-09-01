using UnityEngine;
using Assets.Scripts.Events;

namespace Assets.Scripts.Commands {
    public class GoToMainMenuCommand : Command {
        private CustomEventSystem eventSystem;

        private void Awake() {
            eventSystem = GameObject.FindObjectOfType<CustomEventSystem>();
        }

        public override void Run() {
            eventSystem.FireEvent(typeof(GoToMainMenuEvent));
        }

        public override string ToString() {
            return "NavigateBackCommand";
        }
    }
}
