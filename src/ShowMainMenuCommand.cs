namespace MazeEscapeLibrary.src
{
    public class ShowMainMenuCommand : Command
    {
        public GameController GameController { get; set; }

        public ShowMainMenuCommand(GameController gameController)
        {
            GameController = gameController;
        }

        public void Run()
        {
            GameController.ShowMainMenu();
        }
    }
}
