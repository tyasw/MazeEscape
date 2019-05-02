using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Events;

public class UIManager : MonoBehaviour, Observer {
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
        StopGameEvent stopGameEvent = ClassFactory.GetStopGameEvent();
        PauseGameEvent pauseGameEvent = ClassFactory.GetPauseGameEvent();
        ResumeGameEvent resumeGameEvent = ClassFactory.GetResumeGameEvent();
        watchingEvents.Add(startGameEvent);
        watchingEvents.Add(stopGameEvent);
        watchingEvents.Add(pauseGameEvent);
        watchingEvents.Add(resumeGameEvent);
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
            case "StopGameEvent":
                StopGame();
                break;
            case "PauseGameEvent":
                PauseGame();
                break;
            case "ResumeGameEvent":
                ResumeGame();
                break;
            default:
                Debug.LogError("Should not get here!");
                break;
        }
    }

    private void StartNewGame() {

    }

    private void StopGame() {

    }

    private void PauseGame() {
        // Show pause menu if not already displayed
    }

    private void ResumeGame() {
        // Close pause menu if not already closed
    }
}
