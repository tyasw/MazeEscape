using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts.Events;

public class UIManager : MonoBehaviour, Observer {
    public Canvas MainMenu;
    public Canvas PauseMenu;
    public Canvas HUDOverlay;
    public Text GameTime;
    public ClassFactory ClassFactory { get; set; }
    public List<Subject> Events;

    private bool mazeStarted;
    private float timeStartedMaze;
    private float elapsedTime;

    void Awake() {
        ClassFactory = ClassFactory.GetInstance();
        Events = InitializeEvents();
        AttachToEvents();
        MainMenu.gameObject.SetActive(true);
        PauseMenu.gameObject.SetActive(false);
        HUDOverlay.gameObject.SetActive(false);
        mazeStarted = false;
    }

    private void Update() {
        if (mazeStarted) {
            elapsedTime = Time.time - timeStartedMaze;
            GameTime.text = elapsedTime.ToString();
        }
    }

    private List<Subject> InitializeEvents() {
        List<Subject> watchingEvents = new List<Subject>();
        MazeStartedEvent mazeStartedEvent = ClassFactory.GetMazeStartedEvent();
        StartGameEvent startGameEvent = ClassFactory.GetStartGameEvent();
        StopGameEvent stopGameEvent = ClassFactory.GetStopGameEvent();
        PauseGameEvent pauseGameEvent = ClassFactory.GetPauseGameEvent();
        ResumeGameEvent resumeGameEvent = ClassFactory.GetResumeGameEvent();
        WonGameEvent wonGameEvent = ClassFactory.GetWonGameEvent();
        watchingEvents.Add(mazeStartedEvent);
        watchingEvents.Add(startGameEvent);
        watchingEvents.Add(stopGameEvent);
        watchingEvents.Add(pauseGameEvent);
        watchingEvents.Add(resumeGameEvent);
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
            case "MazeStartedEvent":
                StartTimer();
                break;
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
            case "WonGameEvent":
                StopTimer();
                break;
            default:
                Debug.LogError("Should not get here!");
                break;
        }
    }

    private void StartTimer() {
        mazeStarted = true;
        timeStartedMaze = Time.time;
        HUDOverlay.gameObject.SetActive(true);
    }

    private void StopTimer() {
        mazeStarted = false;
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
