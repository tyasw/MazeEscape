using UnityEngine;
using Assets.Scripts.Events;

namespace Assets.Scripts.Commands {
    /*
     * Start the game timer. This should be run when the player first enters
     * the maze.
     */
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
