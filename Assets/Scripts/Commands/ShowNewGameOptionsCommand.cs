namespace Assets.Scripts.Commands {
    public class ShowNewGameOptionsCommand : Command {
        private GameController GameController { get; set; }

        public ShowNewGameOptionsCommand(GameController gameController) {
            GameController = gameController;
        }

        public override void Run() {
            GameController.ShowGameOptions();
        }

        public override string ToString() {
            return "ShowNewGameOptionsCommand";
        }
    }
}
