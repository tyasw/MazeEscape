using System.Collections.Generic;
using Assets.Scripts.Events;
using UnityEngine;

namespace Assets.Scripts.Commands {
    public class ShowNewGameOptionsCommand : Command {
        private void Start() {
            Subjects = new List<Subject>();
            GameObject EventsObject = GameObject.FindGameObjectWithTag("Events");
            Subject Event = EventsObject.GetComponent<ShowGameOptionsEvent>();
            Subjects.Add(Event);
        }

        public override void Run() {
            base.Run();
        }

        public override string ToString() {
            return "ShowNewGameOptionsCommand";
        }
    }
}
