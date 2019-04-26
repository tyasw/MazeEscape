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
        watchingEvents.Add(new StopGameEvent());
        watchingEvents.Add(new PauseGameEvent());
        watchingEvents.Add(new ResumeGameEvent());
        watchingEvents.Add(new ShowGameOptionsEvent());
        watchingEvents.Add(new StartGameEvent());
        return watchingEvents;
    }

    private void AttachToEvents() {
        foreach(Subject subject in Events) {
            subject.Attach(this);
        }
    }

    public void Update(Subject subject) {
        Debug.Log(subject.ToString());
    }

    public void StartNewGame() {
        GameModel.BeginGameWithOptionsApplied();
        GameView.DrawWorld();
    }

    public void PauseGame() {
        GameOptions.PauseGame();
    }

    public void ResumeGame() {
        GameOptions.ResumeGame();
    }

    public void StopGame() {
        GameOptions.StopGame();
    }

    public void ShowMenu() {
        GameOptions.ShowMainMenu();
    }

    public void ShowGameOptions() {
        GameOptions.ShowGameOptions();
    }
}
