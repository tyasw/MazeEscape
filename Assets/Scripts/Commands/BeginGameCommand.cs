namespace Assets.Scripts.Commands {
    public class BeginGameCommand : Command {
        public GameController GameController { get; set; }
        public GameModel GameModel { get; set; }

        public BeginGameCommand(GameController gameController, GameModel gameModel) {
            GameController = gameController;
            GameModel = gameModel;
        }

        public void Run() {
            GameModel.BeginGameWithOptionsApplied();
            GameController.FireDrawWorld();
        }
    }
}
