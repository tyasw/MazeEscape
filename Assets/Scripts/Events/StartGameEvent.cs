using UnityEngine;
using Assets.Scripts.Commands;

namespace Assets.Scripts.Events {
    class StartGameEvent : MonoBehaviour, GameEvent {
        public EventHandler EventHandler { get; set; }

        public StartGameEvent() {
            EventHandler = EventHandler.GetInstance();
        }

        public void Trigger(GameController gameController) {
            Command command = new BeginGameCommand(gameController);
            EventHandler.Notify(command);
        }
    }
}
