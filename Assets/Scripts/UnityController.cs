using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Events;

/*
 * UnityController
 * 
 * The top-level class in Maze Escape. It creates the game model and view,
 * and subscribes to a few events: StopGameEvent, StartGameEvent, and
 * WonGameEvent. When you need to control the order in which different observers
 * respond to a change, do it here.
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
        watchingEvents.Add(stopGameEvent);
        watchingEvents.Add(startGameEvent);
        watchingEvents.Add(wonGameEvent);
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
            case "WonGameEvent":
                WinGame();
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

    private void WinGame() {
        GameModel.GameData.GameWon = true;
        Debug.Log("Won Game!");
    }
}
