using UnityEngine;
using Assets.Scripts.Commands;

namespace Assets.Scripts.Events {
    class StopGameEvent : MonoBehaviour, GameEvent {
        public EventHandler EventHandler { get; set; }

        public StopGameEvent() {
            EventHandler = EventHandler.GetInstance();
        }

        public void Trigger(GameController gameController) {
            Command command = new StopGameCommand(gameController);
            EventHandler.Notify(command);
        }
    }
}
