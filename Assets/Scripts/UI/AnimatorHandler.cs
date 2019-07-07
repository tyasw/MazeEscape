using UnityEngine;

namespace Assets.Scripts.UI {
    public class AnimatorHandler : MonoBehaviour {
        public Animator HUDAnimator;

        void Awake() {
            HUDAnimator = GameObject.Find("HUD").GetComponent<Animator>();
        }

        public void StartTimer() {
            HUDAnimator.SetBool("InsideMaze", true);
        }

        public void GameWon() {
            HUDAnimator.SetTrigger("WinGame");
        }

        public void StartNewGame() {
            HUDAnimator.SetTrigger("MainMenuDisappear");
        }

        public void PauseGame() {
            HUDAnimator.SetBool("Paused", true);
        }

        public void ResumeGame() {
            HUDAnimator.SetBool("Paused", false);
        }
    }
}
