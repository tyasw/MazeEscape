namespace Assets.Scripts.Commands {
    public class BeginGameCommand : Command {
        public GameController GameController { get; set; }

        public BeginGameCommand(GameController gameController) {
            GameController = gameController;
        }

        public void Run() {
            GameController.StartNewGame();
        }

        public override string ToString() {
            return "BeginGameCommand";
        }
    }
}
