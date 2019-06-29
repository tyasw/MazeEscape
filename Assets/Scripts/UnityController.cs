using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Assets.Scripts.Events;

/*
 * UnityController
 * 
 * The top-level class in Maze Escape. It creates the game model and view,
 * and subscribes to a few events: StopGameEvent, StartGameEvent, and
 * WonGameEvent. When you need to control the order in which different observers
 * respond to a change, do it here.
 */
public class UnityController : MonoBehaviour, GameController {
    public GameModel GameModel;
    public UnityView GameView;
    public GameOptions GameOptions;

    public CustomEventSystem EventSystem;

    void Awake() {
        EventSystem = GameObject.FindObjectOfType<CustomEventSystem>();
        GameModel = GetComponent<GameModel>();
        GameView = GetComponent<UnityView>();
        GameOptions = GetComponent<UnityOptions>();
        InitializeEvents();
    }

    private void Start() {
        StartNewGame();
    }

    private void InitializeEvents() {
        EventSystem.RegisterListener(typeof(StopGameEvent), StopGame);
        EventSystem.RegisterListener(typeof(RestartGameEvent), RestartGame);
        EventSystem.RegisterListener(typeof(WonGameEvent), WinGame);
    }

    public void StartNewGame() {
        GameModel.BeginGameWithOptionsApplied();
        GameView.DrawWorld();
    }

    public void RestartGame() {
        Debug.Log("Load game again");
        SceneManager.LoadScene("Game");
    }

    public void StopGame() {
        GameOptions.StopGame();
    }

    private void WinGame() {
        GameModel.GameData.GameWon = true;
        Debug.Log("Won Game!");
    }
}
