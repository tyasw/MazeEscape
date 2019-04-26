namespace Assets.Scripts.Commands {
    public class ResumeGameCommand : Command {
        private GameController GameController { get; set; }

        public ResumeGameCommand(GameController gameController) {
            GameController = gameController;
        }

        public override void Run() {
            GameController.ResumeGame();
        }

        public override string ToString() {
            return "ResumeGameCommand";
        }
    }
}
