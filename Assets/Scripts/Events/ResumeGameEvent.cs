using UnityEngine;
using Assets.Scripts.Commands;

namespace Assets.Scripts.Events {
    class ResumeGameEvent : MonoBehaviour, GameEvent {
        public EventHandler EventHandler { get; set; }

        public ResumeGameEvent() {
            EventHandler = EventHandler.GetInstance();
        }

        public void Trigger(GameController gameController) {
            Command command = new ResumeGameCommand(gameController);
            EventHandler.Notify(command);
        }
    }
}
