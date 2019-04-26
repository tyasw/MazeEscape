using UnityEngine;
using Assets.Scripts.Events;

namespace Assets.Scripts.Commands {
    public class PauseGameCommand : Command {
        public PauseGameEvent Event { get; set; }

        private void Start() {
            GameObject EventsObject = GameObject.FindGameObjectWithTag("Events");
            Event = EventsObject.GetComponent<PauseGameEvent>();
        }

        public override void Run() {
            Event.Notify();
        }

        public override string ToString() {
            return "PauseGameCommand";
        }
    }
}