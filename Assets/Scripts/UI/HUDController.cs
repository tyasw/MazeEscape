using UnityEngine;
using Assets.Scripts.Events;

namespace Assets.Scripts.UI {
    /*
     * Responds to events the HUD needs to know about. It should be attached
     * to a GameObject in the game scene.
     */
    public class HUDController : MonoBehaviour {
        public CustomEventSystem EventSystem;
        public HUDAnimatorHandler HUDAnimatorHandler;

        private void Awake() {
            EventSystem = GameObject.FindObjectOfType<CustomEventSystem>();
            HUDAnimatorHandler = GetComponent<HUDAnimatorHandler>();
            InitializeEvents();
        }

        private void InitializeEvents() {
            EventSystem.RegisterListener(typeof(MazeStartedEvent), StartTimer);
            EventSystem.RegisterListener(typeof(PauseGameEvent), PauseGame);
            EventSystem.RegisterListener(typeof(ResumeGameEvent), ResumeGame);
            EventSystem.RegisterListener(typeof(WonGameEvent), GameWon);
        }

        public void StartTimer() {
            HUDAnimatorHandler.StartTimer();
        }

        public void GameWon() {
            HUDAnimatorHandler.GameWon();
        }

        public void PauseGame() {
            HUDAnimatorHandler.PauseGame();
        }

        public void ResumeGame() {
            HUDAnimatorHandler.ResumeGame();
        }
    }
}
