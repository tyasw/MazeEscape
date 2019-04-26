using UnityEngine;
using Assets.Scripts.Events;

namespace Assets.Scripts.Commands {
    public class BeginGameCommand : Command {
        public StartGameEvent Event { get; set; }

        private void Start() {
            GameObject EventsObject = GameObject.FindGameObjectWithTag("Events");
            Event = EventsObject.GetComponent<StartGameEvent>();
        }

        public override void Run() {
            Event.Notify();
        }

        public override string ToString() {
            return "BeginGameCommand";
        }
    }
}
