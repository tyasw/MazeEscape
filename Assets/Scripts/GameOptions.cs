using System.Collections.Generic;

public interface GameOptions {
    void PauseGame();
    void ResumeGame();
    void StopGame();
    void ShowMainMenu();
    void ShowGameOptions();
}