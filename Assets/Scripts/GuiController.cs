using System;
using UnityEngine;

public class GuiController : MonoBehaviour {
    public GameModel GameModel { get; set; }
    public GuiView GameView { get; set; }
    public CommandParser CmdParser { get; set; }

    void Start() {
        GameModel = new GameModel();
        GameView = new GuiView(GameModel);
        CmdParser = new CommandParser();

        AddCommand(new ShowNewGameOptionsCommand(this));
        AddCommand(new BeginGameCommand(this,GameModel));
    }

    void Update() {
        RunNextCommand();
    }

    public void ShowMainMenu() {
        throw new NotImplementedException();
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
