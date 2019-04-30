using System.Collections.Generic;

public interface GameOptions {
    List<Subject> Events { get; set; }

    void PauseGame();
    void ResumeGame();
    void StopGame();
    void ShowMainMenu();
    void ShowGameOptions();
}