using System;
using UnityEngine;

public class UnityHandler : MonoBehaviour, GameOptions  {
    private float SavedTimeScale { get; set; }

    public void StartGame() {
        throw new NotImplementedException();
    }

    public void PauseGame() {
        SavedTimeScale = Time.timeScale;
        Time.timeScale = 0.0f;
    }

    public void ResumeGame() {
        Time.timeScale = SavedTimeScale;
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
        } catch (Exception ex) {
            LogError(ex);
        }
    }

    private void GetMazeWidthAndHeightFromUser() {

    }

    private void LogError(Exception ex) {
        Console.WriteLine(ex.Message);
    }
}
