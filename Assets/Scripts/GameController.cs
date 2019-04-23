using Assets.Scripts.Commands;

public interface GameController {
    GameModel GameModel { get; set; }
    GameView GameView { get; set; }
    CommandParser CommandParser { get; set; }
    CommandRunner CommandRunner { get; set; }
    GameOptions GameOptions { get; set; }

    void AddCommand(Command command);
    void StartNewGame();
    void PauseGame();
    void ResumeGame();
    void ShowMenu();
}