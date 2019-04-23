using Assets.Scripts.Commands;

public class UnityController : GameController {
    public GameModel GameModel { get; set; }
    public GameView GameView { get; set; }
    public CommandParser CommandParser { get; set; }
    public CommandRunner CommandRunner { get; set; }
    public GameOptions GameOptions { get; set; }

    public UnityController(GameModel gameModel, GameView gameView, CommandParser commandParser, CommandRunner commandRunner, GameOptions gameOptions) {
        GameModel = gameModel;
        GameView = gameView;
        CommandParser = commandParser;
        CommandRunner = commandRunner;
        GameOptions = gameOptions;
    }

    public void AddCommand(Command command) {
        CommandParser.AddCommand(command);
    }

    public void StartNewGame() {
        GameModel.BeginGameWithOptionsApplied();
    }

    public void PauseGame() {
        GameOptions.PauseGame();
    }

    public void ResumeGame() {
        GameOptions.ResumeGame();
    }

    public void ShowMenu() {
        GameOptions.ShowMainMenu();
    }
}
