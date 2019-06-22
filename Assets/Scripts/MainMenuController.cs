using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Assets.Scripts.Events;

public class MainMenuController : MonoBehaviour, Observer {
    public ClassFactory ClassFactory { get; set; }
    public List<Subject> Events;

    void Awake() {
        ClassFactory = ClassFactory.GetInstance();
        Events = InitializeEvents();
        AttachToEvents();
    }

    private List<Subject> InitializeEvents() {
        List<Subject> watchingEvents = new List<Subject>();
        StartGameEvent startGameEvent = ClassFactory.GetStartGameEvent();
        watchingEvents.Add(startGameEvent);
        return watchingEvents;
    }

    private void AttachToEvents() {
        foreach (Subject subject in Events) {
            subject.Attach(this);
        }
    }

    public void UpdateObserver(Subject subject) {
        switch (subject.ToString()) {
            case "StartGameEvent":
                StartNewGame();
                break;
            default:
                Debug.LogError("Should not get here!");
                break;
        }
    }

    public void StartNewGame() {
        SceneManager.LoadScene("Game");
    }
}