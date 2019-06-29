using System;
using UnityEngine;
using Assets.Scripts.Events;

public class UnityOptions : MonoBehaviour, GameOptions {
    private float SavedTimeScale { get; set; }

    public CustomEventSystem EventSystem;

    void Awake() {
        EventSystem = GameObject.FindObjectOfType<CustomEventSystem>();
        InitializeEvents();
    }

    private void InitializeEvents() {
        EventSystem.RegisterListener(typeof(PauseGameEvent), PauseGame);
        EventSystem.RegisterListener(typeof(ResumeGameEvent), ResumeGame);
        EventSystem.RegisterListener(typeof(ShowGameOptionsEvent), ShowGameOptions);
        EventSystem.RegisterListener(typeof(RestartGameEvent), RestartGame);
    }

    public void PauseGame() {
        Debug.Log("Pause Game!");
    }

    public void ResumeGame() {
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

    public void RestartGame() {
        Debug.Log("Restart Game");
    }

    private void GetMazeWidthAndHeightFromUser() {
        throw new NotImplementedException();
    }

    private void LogError(Exception ex) {
        Debug.LogError(ex.Message);
    }
}