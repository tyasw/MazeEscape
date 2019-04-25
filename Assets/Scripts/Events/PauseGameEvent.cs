using UnityEngine;
using Assets.Scripts.Commands;

namespace Assets.Scripts.Events {
    class PauseGameEvent : MonoBehaviour, GameEvent {
        public EventHandler EventHandler { get; set; }

        public PauseGameEvent() {
            EventHandler = EventHandler.GetInstance();
        }

        public void Trigger(GameController gameController) {
            Command command = new PauseGameCommand(gameController);
            EventHandler.Notify(command);
        }
    }
}
