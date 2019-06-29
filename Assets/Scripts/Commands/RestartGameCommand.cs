using UnityEngine;
using Assets.Scripts.Events;

namespace Assets.Scripts.Commands {
    /*
     * Start fresh from the beginning of the maze.
     */
    public class RestartGameCommand : Command {
        private CustomEventSystem eventSystem;

        private void Awake() {
            eventSystem = GameObject.FindObjectOfType<CustomEventSystem>();
        }

        public override void Run() {
            eventSystem.FireEvent(typeof(RestartGameEvent));
        }

        public override string ToString() {
            return "RestartGameCommand";
        }
    }
}
