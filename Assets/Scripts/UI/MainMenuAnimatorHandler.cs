using UnityEngine;

namespace Assets.Scripts.UI {
    public class MainMenuAnimatorHandler : MonoBehaviour {
        public Animator MainMenuAnimator;

        void Awake() {
            MainMenuAnimator = GameObject.Find("MainMenu").GetComponent<Animator>();
        }

        public void StartNewGame() {
            MainMenuAnimator.SetTrigger("MainMenuDisappear");
        }
    }
}
