using System;
using UnityEngine;
using Scripts.Commands;

public class GuiController : MonoBehaviour {
    public GameModel GameModel { get; set; }
    public GuiView GameView { get; set; }
    public CommandParser CmdParser { get; set; }
    public GameOptions GameOptions { get; set; }

    void Start() {
        GameModel = new GameModel();
        GameView = new GuiView(GameModel);
        CmdParser = new CommandParser();
        GameOptions = new UnityGameOptions();

        AddCommand(new ShowNewGameOptionsCommand(this));
        AddCommand(new BeginGameCommand(this,GameModel));
    }

    void Update() {
        RunNextCommand();
    }

    public void ShowMainMenu() {
        GameOptions.ShowMainMenu();
    }

    public void StartGame() {
        GameOptions.StartGame();
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

    public void AddCommand(Command command) {
        CmdParser.AddCommand(command);
    }

    public void ShowGameOptions() {
        try {
            GetMazeWidthAndHeightFromUser();
        } catch (Exception ex) {
            LogError(ex);
        }
    }

    private void LogError(Exception ex) {
        Console.WriteLine(ex.Message);
    }

    private void GetMazeWidthAndHeightFromUser() {

    }

    public void FireDrawMaze() {
        GameView.ShowMaze();
    }

    public void FireDrawWorld() {
        //...
        FireDrawMaze();
    }

    public void RunNextCommand() {
        CmdParser.RunNextCommand();
    }
}
