using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Events;

/*
 * UnityController
 * 
 * The top-level class in Maze Escape. It creates the game model and view,
 * and subscribes to a couple events: StopGameEvent and StartGameEvent.
 */
public class UnityController : MonoBehaviour, GameController, Observer {
    public ClassFactory ClassFactory { get; set; }
    public GameModel GameModel;
    public GameView GameView;
    public GameOptions GameOptions;
    public List<Subject> Events;

    void Awake() {
        ClassFactory = ClassFactory.GetInstance();
        GameModel = ClassFactory.GetGameModel();
        GameView = GetComponent<UnityView>();
        GameOptions = GetComponent<UnityOptions>();
        Events = InitializeEvents();
        AttachToEvents();
    }

    private List<Subject> InitializeEvents() {
        List<Subject> watchingEvents = new List<Subject>();
        StopGameEvent stopGameEvent = ClassFactory.GetStopGameEvent();
        StartGameEvent startGameEvent = ClassFactory.GetStartGameEvent();
        WonGameEvent wonGameEvent = ClassFactory.GetWonGameEvent();
        GameData gameData = ClassFactory.GetGameData();
        watchingEvents.Add(stopGameEvent);
        watchingEvents.Add(startGameEvent);
        watchingEvents.Add(gameData);
        return watchingEvents;
    }

    private void AttachToEvents() {
        foreach (Subject subject in Events) {
            subject.Attach(this);
        }
    }

    public void UpdateObserver(Subject subject) {
        switch (subject.ToString()) {
            case "StopGameEvent":
                StopGame();
                break;
            case "StartGameEvent":
                StartNewGame();
                break;
            case "GameData":
                HandleGameDataChanged(subject as GameData);
                break;
            default:
                Debug.LogError("Should not get here!");
                break;
        }
    }

    public void StartNewGame() {
        GameModel.BeginGameWithOptionsApplied();
        GameView.DrawWorld();
    }

    public void StopGame() {
        GameOptions.StopGame();
    }

    private void HandleGameDataChanged(GameData gameData) {
        if (gameData.GameWon) {
            Debug.Log("Won Game!");
        }
    }
}
