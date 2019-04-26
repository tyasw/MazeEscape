namespace Assets.Scripts.Commands {
    public class PauseGameCommand : Command {
        private GameController GameController { get; set; }

        public PauseGameCommand(GameController gameController) {
            GameController = gameController;
        }

        public override void Run() {
            GameController.PauseGame();
        }

        public override string ToString() {
            return "PauseGameCommand";
        }
    }
}