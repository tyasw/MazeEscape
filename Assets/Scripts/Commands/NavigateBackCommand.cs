using UnityEngine;
using Assets.Scripts.Events;

namespace Assets.Scripts.Commands {
    public class NavigateBackCommand : Command {
        private CustomEventSystem eventSystem;

        private void Awake() {
            eventSystem = GameObject.FindObjectOfType<CustomEventSystem>();
        }

        public override void Run() {
            eventSystem.FireEvent(typeof(NavigateBackEvent));
        }

        public override string ToString() {
            return "NavigateBackCommand";
        }
    }
}
