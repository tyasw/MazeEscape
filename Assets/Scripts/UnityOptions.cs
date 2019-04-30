using System;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Events;

public class UnityOptions : MonoBehaviour, GameOptions, Observer {
    private float SavedTimeScale { get; set; }
    public List<Subject> Events { get; set; }

    void Start() {
        Events = InitializeEvents();
        AttachToEvents();
    }

    private List<Subject> InitializeEvents() {
        List<Subject> watchingEvents = new List<Subject>();
        GameObject EventObject = GameObject.FindGameObjectWithTag("Events");
        PauseGameEvent PauseGameEvent = EventObject.GetComponent<PauseGameEvent>();
        ResumeGameEvent ResumeGameEvent = EventObject.GetComponent<ResumeGameEvent>();
        ShowGameOptionsEvent ShowGameOptionsEvent = EventObject.GetComponent<ShowGameOptionsEvent>();
        watchingEvents.Add(PauseGameEvent);
        watchingEvents.Add(ResumeGameEvent);
        watchingEvents.Add(ShowGameOptionsEvent);
        return watchingEvents;
    }

    private void AttachToEvents() {
        foreach (Subject subject in Events) {
            subject.Attach(this);
        }
    }

    public void UpdateObserver(Subject subject) {
        switch (subject.ToString()) {
            case "PauseGameEvent":
                PauseGame();
                break;
            case "ResumeGameEvent":
                ResumeGame();
                break;
            case "ShowGameOptionsEvent":
                ShowGameOptions();
                break;
            default:
                Debug.LogError("Should not get here!");
                break;
        }
    }

    public void PauseGame() {
        SavedTimeScale = Time.timeScale;
        Time.timeScale = 0.0f;
        Debug.Log("Pause Game!");
    }

    public void ResumeGame() {
        Time.timeScale = SavedTimeScale;
        Debug.Log("Resume Game!");
    }

    public void StopGame() {
        throw new NotImplementedException();
    }

    public void ShowMainMenu() {
        throw new NotImplementedException();
    }

    public void ShowGameOptions() {
        try {
            GetMazeWidthAndHeightFromUser();
            Debug.Log("Show Game Options!");
        } catch (Exception ex) {
            LogError(ex);
        }
    }

    private void GetMazeWidthAndHeightFromUser() {
        throw new NotImplementedException();
    }

    private void LogError(Exception ex) {
        Debug.LogError(ex.Message);
    }
}