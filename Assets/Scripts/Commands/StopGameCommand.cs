using UnityEngine;
using Assets.Scripts.Events;

namespace Assets.Scripts.Commands {
    public class StopGameCommand : Command {
        public StopGameEvent Event { get; set; }

        private void Start() {
            GameObject EventsObject = GameObject.FindGameObjectWithTag("Events");
            Event = EventsObject.GetComponent<StopGameEvent>();
        }

        public override void Run() {
            Event.Notify();
        }

        public override string ToString() {
            return "StopGameCommand";
        }
    }
}