using Assets.Scripts.Events;
using UnityEngine;

namespace Assets.Scripts.Commands {
    public class ShowNewGameOptionsCommand : Command {
        public ShowGameOptionsEvent Event { get; set; }

        private void Start() {
            GameObject EventsObject = GameObject.FindGameObjectWithTag("Events");
            Event = EventsObject.GetComponent<ShowGameOptionsEvent>();
        }

        public override void Run() {
            Event.Notify();
        }

        public override string ToString() {
            return "ShowNewGameOptionsCommand";
        }
    }
}
