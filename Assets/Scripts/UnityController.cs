using UnityEngine;
using Assets.Scripts.Commands;

public class UnityController : MonoBehaviour, GameController {
    public GameModel GameModel;
    public GameView GameView;
    public EventHandler EventHandler;
    public CommandParser CommandParser;
    public CommandRunner CommandRunner;
    public GameOptions GameOptions;

    void Start() {
        GameModel = GameModel.GetInstance();
        GameView = GetComponent<UnityView>();
        EventHandler = EventHandler.GetInstance();
        CommandParser = CommandParser.GetInstance();
        CommandRunner = new CommandRunner(CommandParser);
        GameOptions = GetComponent<UnityOptions>();

        AddCommand(new ShowNewGameOptionsCommand(this));
        AddCommand(new BeginGameCommand(this));
    }

    void Update() {
        CommandRunner.RunNextCommand();
    }

    public void AddCommand(Command command) {
        CommandParser.AddCommand(command);
    }

    public void StartNewGame() {
        GameModel.BeginGameWithOptionsApplied();
        GameView.DrawWorld();
    }

    public void PauseGame() {
        GameOptions.PauseGame();
    }

    public void ResumeGame() {
        GameOptions.ResumeGame();
    }

    public void StopGame() {
        GameOptions.StopGame();
    }

    public void ShowMenu() {
        GameOptions.ShowMainMenu();
    }

    public void ShowGameOptions() {
        GameOptions.ShowGameOptions();
    }
}
