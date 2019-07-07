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
        public AnimatorHandler AnimatorHandler;

        void Awake() {
            EventSystem = GameObject.FindObjectOfType<CustomEventSystem>();
            InitializeEvents();
            HUDOverlay.gameObject.SetActive(true);
            GameTimer.gameObject.SetActive(false);
            AnimatorHandler = GetComponent<AnimatorHandler>();
        }

        private void InitializeEvents() {
            EventSystem.RegisterListener(typeof(MazeStartedEvent), StartTimer);
            EventSystem.RegisterListener(typeof(StartGameEvent), StartNewGame);
            EventSystem.RegisterListener(typeof(PauseGameEvent), PauseGame);
            EventSystem.RegisterListener(typeof(ResumeGameEvent), ResumeGame);
            EventSystem.RegisterListener(typeof(WonGameEvent), GameWon);
        }

        private void StartTimer() {
            AnimatorHandler.StartTimer();
        }

        private void GameWon() {
            AnimatorHandler.GameWon();
        }

        private void StartNewGame() {
            AnimatorHandler.StartNewGame();
        }

        private void PauseGame() {
            AnimatorHandler.PauseGame();
        }

        private void ResumeGame() {
            AnimatorHandler.ResumeGame();
        }
    }
}
