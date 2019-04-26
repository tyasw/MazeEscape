using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Events;

public class UnityController : MonoBehaviour, GameController, Observer {
    public GameModel GameModel;
    public GameView GameView;
    public EventHandler EventHandler;
    public GameOptions GameOptions;
    public List<Subject> Events;

    void Start() {
        GameModel = GameModel.GetInstance();
        GameView = GetComponent<UnityView>();
        EventHandler = EventHandler.GetInstance();
        GameOptions = GetComponent<UnityOptions>();
        Events = InitializeEvents();
        AttachToEvents();
    }

    private List<Subject> InitializeEvents() {
        List<Subject> watchingEvents = new List<Subject>();
        GameObject EventObject = GameObject.FindGameObjectWithTag("Events");
        StopGameEvent StopGameEvent = EventObject.GetComponent<StopGameEvent>();
        StartGameEvent StartGameEvent = EventObject.GetComponent<StartGameEvent>();
        watchingEvents.Add(StopGameEvent);
        watchingEvents.Add(StartGameEvent);
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
}
