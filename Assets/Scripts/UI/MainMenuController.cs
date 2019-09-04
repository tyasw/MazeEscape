using UnityEngine;
using UnityEngine.SceneManagement;
using Assets.Scripts.Events;

namespace Assets.Scripts.UI {
    /*
     * Responds to events triggered in the Main Menu. It should be attached to
     * a GameObject in the MainMenu scene.
     */
    public class MainMenuController : MonoBehaviour {
        public CustomEventSystem EventSystem;
        public MainMenuAnimatorHandler MainMenuAnimatorHandler;

        void Awake() {
            EventSystem = GameObject.FindObjectOfType<CustomEventSystem>();
            MainMenuAnimatorHandler = GetComponent<MainMenuAnimatorHandler>();
            InitializeEvents();
        }

        private void InitializeEvents() {
            EventSystem.RegisterListener(typeof(StartGameEvent), StartNewGame);
            EventSystem.RegisterListener(typeof(NavigateBackEvent), NavigateBack);
            EventSystem.RegisterListener(typeof(LoadNewGameScreenEvent), LoadNewGameScreen);
        }

        public void StartNewGame() {
            GameObject gameDataGameObject = GameObject.FindGameObjectWithTag("GameData");
            MazeDataManager mazeDataManager = gameDataGameObject.gameObject.GetComponent<MazeDataManager>();
            mazeDataManager.GetMazeOptions();       // TODO: What happens if error in user input? Don't load new scene 
            SceneManager.LoadScene("Game");
            MainMenuAnimatorHandler.StartNewGame();
        }

        public void LoadNewGameScreen() {
            MainMenuAnimatorHandler.LoadNewGameScreen();
        }

        public void NavigateBack() {
            MainMenuAnimatorHandler.NavigateBack();
        }
    }
}