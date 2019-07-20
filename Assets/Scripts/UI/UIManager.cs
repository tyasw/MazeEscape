using UnityEngine;
using Assets.Scripts.Events;

namespace Assets.Scripts.UI {
    /*
     * Controls the UI in the game. The UIManager is notified when certain
     * events occur, and triggers something on the animator attached to the HUD.
     * This class must be attached to a GameObject in the main scene in Unity.
     */
    public class UIManager : MonoBehaviour {
        public Canvas HUDOverlay;
        public GameTimer GameTimer;
        public CustomEventSystem EventSystem;
        public HUDAnimatorHandler HUDAnimatorHandler;

        void Awake() {
            EventSystem = GameObject.FindObjectOfType<CustomEventSystem>();
            InitializeEvents();
            HUDOverlay.gameObject.SetActive(true);
            GameTimer.gameObject.SetActive(false);
            HUDAnimatorHandler = GetComponent<HUDAnimatorHandler>();
        }

        private void InitializeEvents() {
            EventSystem.RegisterListener(typeof(MazeStartedEvent), StartTimer);
            EventSystem.RegisterListener(typeof(PauseGameEvent), PauseGame);
            EventSystem.RegisterListener(typeof(ResumeGameEvent), ResumeGame);
            EventSystem.RegisterListener(typeof(WonGameEvent), GameWon);
        }

        private void StartTimer() {
            HUDAnimatorHandler.StartTimer();
        }

        private void GameWon() {
            HUDAnimatorHandler.GameWon();
        }

        private void PauseGame() {
            HUDAnimatorHandler.PauseGame();
        }

        private void ResumeGame() {
            HUDAnimatorHandler.ResumeGame();
        }
    }
}
