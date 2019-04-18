using Assets.Scripts.Commands;

public interface GameController {
    GameModel GameModel { get; set; }
    GameView GameView { get; set; }
    CommandParser CmdParser { get; set; }
    GameOptions GameOptions { get; set; }

    void AddCommand(Command command);
    void FireDrawMaze();
    void FireDrawWorld();
    void RunNextCommand();
}