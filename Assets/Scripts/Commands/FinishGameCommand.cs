using UnityEngine;
using Assets.Scripts.Events;

namespace Assets.Scripts.Commands {
    /*
     * The player has completed the maze.
     */
    public class FinishGameCommand : Command {
        private CustomEventSystem eventSystem;

        private void Awake() {
            eventSystem = GameObject.FindObjectOfType<CustomEventSystem>();
        }

        public override void Run() {
            eventSystem.FireEvent(typeof(WonGameEvent));
        }

        public override string ToString() {
            return "WonGameCommand";
        }
    }
}
