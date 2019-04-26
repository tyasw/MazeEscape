namespace Assets.Scripts.Commands {
    public class BeginGameCommand : Command {
        public GameController GameController { get; set; }

        public BeginGameCommand(GameController gameController) {
            GameController = gameController;
        }

        public override void Run() {
            GameController.StartNewGame();
        }

        public override string ToString() {
            return "BeginGameCommand";
        }
    }
}
