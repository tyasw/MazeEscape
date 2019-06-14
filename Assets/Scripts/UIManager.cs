using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Events;

public class UIManager : MonoBehaviour, Observer {
    public Canvas HUDOverlay;
    public Animator HUDAnimator;
    public GameTimer GameTimer;
    public ClassFactory ClassFactory { get; set; }
    public List<Subject> Events;

    void Awake() {
        ClassFactory = ClassFactory.GetInstance();
        Events = InitializeEvents();
        AttachToEvents();
        HUDOverlay.gameObject.SetActive(true);
        GameTimer.gameObject.SetActive(false);
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
                GameWon();
                break;
            default:
                Debug.LogError("Should not get here!");
                break;
        }
    }

    private void StartTimer() {
        HUDAnimator.SetBool("InsideMaze", true);
    }

    private void GameWon() {
        HUDAnimator.SetTrigger("WinGame");
    }

    private void StartNewGame() {
        HUDAnimator.SetTrigger("MainMenuDisappear");
    }

    private void StopGame() {

    }

    private void PauseGame() {
        HUDAnimator.SetBool("Paused", true);
    }

    private void ResumeGame() {
        HUDAnimator.SetBool("Paused", false);
    }
}
