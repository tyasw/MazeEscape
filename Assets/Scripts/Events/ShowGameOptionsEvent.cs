using UnityEngine;
using Assets.Scripts.Commands;

namespace Assets.Scripts.Events {
    class ShowGameOptionsEvent : MonoBehaviour, GameEvent {
        public EventHandler EventHandler { get; set; }

        public ShowGameOptionsEvent() {
            EventHandler = EventHandler.GetInstance();
        }

        public void Trigger(GameController gameController) {
            Command command = new ShowNewGameOptionsCommand(gameController);
            EventHandler.Notify(command);
        }
    }
}
