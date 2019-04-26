using System.Collections.Generic;
using Assets.Scripts.Events;
using UnityEngine;

namespace Assets.Scripts.Commands {
    public class ShowNewGameOptionsCommand : Command {
        private void Start() {
            Events = new List<GameEvent>();
            GameObject EventsObject = GameObject.FindGameObjectWithTag("Events");
            GameEvent Event = EventsObject.GetComponent<ShowGameOptionsEvent>();
            Events.Add(Event);
        }

        public override void Run() {
            foreach (GameEvent Event in Events) {
                Event.Notify();
            }
        }

        public override string ToString() {
            return "ShowNewGameOptionsCommand";
        }
    }
}
