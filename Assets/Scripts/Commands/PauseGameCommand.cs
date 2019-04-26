using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Events;

namespace Assets.Scripts.Commands {
    public class PauseGameCommand : Command {
        private void Start() {
            Events = new List<GameEvent>();
            GameObject EventsObject = GameObject.FindGameObjectWithTag("Events");
            GameEvent Event = EventsObject.GetComponent<PauseGameEvent>();
            Events.Add(Event);
        }

        public override void Run() {
            foreach (GameEvent Event in Events) {
                Event.Notify();
            }
        }

        public override string ToString() {
            return "PauseGameCommand";
        }
    }
}