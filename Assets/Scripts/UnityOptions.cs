using System;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Events;

public class UnityOptions : MonoBehaviour, GameOptions, Observer {
    private float SavedTimeScale { get; set; }
    public ClassFactory ClassFactory { get; set; }
    public List<Subject> Events { get; set; }

    void Awake() {
        ClassFactory = ClassFactory.GetInstance();
        Events = InitializeEvents();
        AttachToEvents();
    }

    private List<Subject> InitializeEvents() {
        List<Subject> watchingEvents = new List<Subject>();
        PauseGameEvent pauseGameEvent = ClassFactory.GetPauseGameEvent();
        ResumeGameEvent resumeGameEvent = ClassFactory.GetResumeGameEvent();
        ShowGameOptionsEvent showGameOptionsEvent = ClassFactory.GetShowGameOptionsEvent();
        watchingEvents.Add(pauseGameEvent);
        watchingEvents.Add(resumeGameEvent);
        watchingEvents.Add(showGameOptionsEvent);
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
        //SavedTimeScale = Time.timeScale;
        //Time.timeScale = 0.0f;
        Debug.Log("Pause Game!");
    }

    public void ResumeGame() {
        //Time.timeScale = SavedTimeScale;
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