using UnityEngine;
using Assets.Scripts.Events;

namespace Assets.Scripts.Commands {
    /*
     * Display the new game options dialog.
     */
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
