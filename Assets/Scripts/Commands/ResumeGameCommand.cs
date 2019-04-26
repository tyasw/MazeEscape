using UnityEngine;
using Assets.Scripts.Events;

namespace Assets.Scripts.Commands {
    public class ResumeGameCommand : Command {
        public ResumeGameEvent Event { get; set; }

        private void Start() {
            GameObject EventsObject = GameObject.FindGameObjectWithTag("Events");
            Event = EventsObject.GetComponent<ResumeGameEvent>();
        }

        public override void Run() {
            Event.Notify();
        }

        public override string ToString() {
            return "ResumeGameCommand";
        }
    }
}
