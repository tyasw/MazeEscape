using Assets.Scripts.Commands;

public interface GameController {
    void AddCommand(Command command);
    void StartNewGame();
    void PauseGame();
    void ResumeGame();
    void StopGame();
    void ShowMenu();
    void ShowGameOptions();
}