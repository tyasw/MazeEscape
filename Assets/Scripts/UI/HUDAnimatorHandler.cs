using UnityEngine;

namespace Assets.Scripts.UI {
    public class HUDAnimatorHandler : MonoBehaviour {
        public Animator HUDAnimator;
        public Canvas HUDOverlay;
        public GameTimer GameTimer;

        void Awake() {
            HUDOverlay.gameObject.SetActive(true);
            GameTimer.gameObject.SetActive(false);
            HUDAnimator = GameObject.Find("HUD").GetComponent<Animator>();
        }

        public void StartTimer() {
            HUDAnimator.SetBool("InsideMaze", true);
        }

        public void GameWon() {
            HUDAnimator.SetTrigger("WinGame");
        }

        public void PauseGame() {
            HUDAnimator.SetBool("Paused", true);
        }

        public void ResumeGame() {
            HUDAnimator.SetBool("Paused", false);
        }
    }
}
