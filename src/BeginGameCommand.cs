namespace MazeEscapeLibrary.src
{
    public class BeginGameCommand : Command
    {
        protected GameController GameController { get; set; }
        protected GameModel GameModel { get; set; }

        public BeginGameCommand(GameController gameController, GameModel gameModel)
        {
            GameController = gameController;
            GameModel = gameModel;
        }

        public void Run()
        {
            GameModel.BeginGameWithOptionsApplied();
            GameController.FireDrawWorld();
        }
    }
}
