using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Events;

public class UIManager : MonoBehaviour, Observer {
    public Canvas MainMenu;
    public Canvas PauseMenu;
    public ClassFactory ClassFactory { get; set; }
    public List<Subject> Events;

    void Awake() {
        ClassFactory = ClassFactory.GetInstance();
        Events = InitializeEvents();
        AttachToEvents();
        MainMenu.gameObject.SetActive(true);
        PauseMenu.gameObject.SetActive(false);
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
        bool mainMenuShown = MainMenu.gameObject.activeSelf;
        if (mainMenuShown) {
            MainMenu.gameObject.SetActive(false);
        }
    }

    private void StopGame() {

    }

    private void PauseGame() {
        bool menuShown = PauseMenu.gameObject.activeSelf;
        if (!menuShown) {       // Sanity check
            PauseMenu.gameObject.SetActive(true);
        }
    }

    private void ResumeGame() {
        bool menuShown = PauseMenu.gameObject.activeSelf;
        if (menuShown) {        // Sanity check
            PauseMenu.gameObject.SetActive(false);
        }
    }
}
