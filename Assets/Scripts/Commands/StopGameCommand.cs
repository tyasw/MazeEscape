using UnityEngine;
using Assets.Scripts.Events;

namespace Assets.Scripts.Commands {
    /*
     * Exit the game. The user should not be returned to the main menu.
     */
    public class StopGameCommand : Command {
        private CustomEventSystem eventSystem;

        private void Awake() {
            eventSystem = GameObject.FindObjectOfType<CustomEventSystem>();
        }

        public override void Run() {
            eventSystem.FireEvent(typeof(StopGameEvent));
        }

        public override string ToString() {
            return "StopGameCommand";
        }
    }
}