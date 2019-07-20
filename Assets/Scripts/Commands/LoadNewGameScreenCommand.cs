using UnityEngine;
using Assets.Scripts.Events;

namespace Assets.Scripts.Commands {
    public class LoadNewGameScreenCommand : Command {
        private CustomEventSystem eventSystem;

        private void Awake() {
            eventSystem = GameObject.FindObjectOfType<CustomEventSystem>();
        }

        public override void Run() {
            eventSystem.FireEvent(typeof(LoadNewGameScreenEvent));
        }

        public override string ToString() {
            return "LoadNewGameScreenCommand";
        }
    }
}
