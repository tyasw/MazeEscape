using System;
using UnityEngine;
using Assets.Scripts.Commands;

public class UnityController : MonoBehaviour, GameController {
    public GameModel GameModel { get; set; }
    public GameView GameView { get; set; }
    public CommandParser CmdParser { get; set; }
    public GameOptions GameOptions { get; set; }

    void Start() {
        GameModel = new GameModel();
        GameView = new UnityView(GameModel);
        CmdParser = new CommandParser();
        GameOptions = GetComponent<UnityOptions>();

        AddCommand(new ShowNewGameOptionsCommand(GameOptions));
        AddCommand(new BeginGameCommand(GameModel, GameView));
        AddCommand(new PauseGameCommand(GameOptions));
        AddCommand(new ResumeGameCommand(GameOptions));
    }

    void Update() {
        RunNextCommand();
    }

    public void AddCommand(Command command) {
        CmdParser.AddCommand(command);
    }

    public void RunNextCommand() {
        string commandName = CmdParser.RunNextCommand();
        if (commandName != "") {
            Debug.Log(commandName + " was just run");
        }
    }
}
