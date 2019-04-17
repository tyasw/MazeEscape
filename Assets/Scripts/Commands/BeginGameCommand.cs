namespace Assets.Scripts.Commands {
    public class BeginGameCommand : Command {
        public GuiController GameController { get; set; }
        public GameModel GameModel { get; set; }

        public BeginGameCommand(GuiController gameController, GameModel gameModel) {
            GameController = gameController;
            GameModel = gameModel;
        }

        public void Run() {
            GameModel.BeginGameWithOptionsApplied();
            GameController.FireDrawWorld();
        }
    }
}
