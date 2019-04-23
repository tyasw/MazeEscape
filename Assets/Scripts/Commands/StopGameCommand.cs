namespace Assets.Scripts.Commands {
    public class StopGameCommand : Command {
        private GameController GameController { get; set; }

        public StopGameCommand(GameController gameController) {
            GameController = gameController;
        }

        public void Run() {
            GameController.StopGame();
        }

        public override string ToString() {
            return "StopGameCommand";
        }
    }
}