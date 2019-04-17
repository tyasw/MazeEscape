using System;
using UnityEngine;

public class UnityHandler : MonoBehaviour  {
    void Start() {
        
    }

    void Update() {
        
    }

    public void StartGame() {
        throw new NotImplementedException();
    }

    public void PauseGame() {
        throw new NotImplementedException();
    }

    public void ResumeGame() {
        throw new NotImplementedException();
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
