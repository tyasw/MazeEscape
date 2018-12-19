/** GameController.cs
 * 
 * Controls the execution of the game.
 */
namespace MazeEscapeLibrary.src
{
    public interface GameController
    {
        GameModel GameModel { get; set; }
        GameView GameView { get; set; }
        CommandParser CmdParser { get; set; }

        // Every once in a while, check if there are commands to run, and run them
        void Start();
        
        // Add a command to be executed
        void AddCommand(Command command);

        void RunNextCommand();

        void ShowGameOptions();

        void FireDrawMaze();

        void FireDrawWorld();
    }
}
