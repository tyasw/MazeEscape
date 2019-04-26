using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Events;

namespace Assets.Scripts.Commands {
    public class BeginGameCommand : Command {
        private void Start() {
            Subjects = new List<Subject>();
            GameObject EventsObject = GameObject.FindGameObjectWithTag("Events");
            Subject Event = EventsObject.GetComponent<StartGameEvent>();
            Subjects.Add(Event);
        }

        public override void Run() {
            base.Run();
        }

        public override string ToString() {
            return "BeginGameCommand";
        }
    }
}
