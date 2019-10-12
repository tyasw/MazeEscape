using UnityEngine;
using UnityEngine.SceneManagement;
using Assets.Scripts.Events;
using System;

namespace Assets.Scripts.UI {
    /*
     * Responds to events triggered in the Main Menu. It should be attached to
     * a GameObject in the MainMenu scene.
     */
    public class MainMenuController : MonoBehaviour {
        public CustomEventSystem EventSystem;
        public MainMenuAnimatorHandler MainMenuAnimatorHandler;
        public NewGameController NewGameController;

        void Awake() {
            EventSystem = GameObject.FindObjectOfType<CustomEventSystem>();
            MainMenuAnimatorHandler = GetComponent<MainMenuAnimatorHandler>();
            NewGameController = GameObject.FindObjectOfType<NewGameController>();
            InitializeEvents();
        }

        private void InitializeEvents() {
            EventSystem.RegisterListener(typeof(StartGameEvent), StartNewGame);
            EventSystem.RegisterListener(typeof(NavigateBackEvent), NavigateBack);
            EventSystem.RegisterListener(typeof(LoadNewGameScreenEvent), LoadNewGameScreen);
        }

        public void StartNewGame() {
            try {
                bool canStart = NewGameController.CanStartNewGame();
                if (canStart) {
                    GameObject gameDataGameObject = GameObject.FindGameObjectWithTag("GameData");
                    MazeDataManager mazeDataManager = gameDataGameObject.gameObject.GetComponent<MazeDataManager>();
                    mazeDataManager.GetMazeOptions();
                    SceneManager.LoadScene("Game");
                    MainMenuAnimatorHandler.StartNewGame();
                }
            } catch (FormatException ex) {
                Debug.Log(ex.Message);
            }
        }

        public void LoadNewGameScreen() {
            MainMenuAnimatorHandler.LoadNewGameScreen();
        }

        public void NavigateBack() {
            MainMenuAnimatorHandler.NavigateBack();
        }
    }
}