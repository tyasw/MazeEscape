namespace Assets.Scripts.Commands {
    public class PauseGameCommand : Command {
        private GameOptions GameOptions { get; set; }

        public PauseGameCommand(GameOptions gameOptions) {
            GameOptions = gameOptions;
        }

        public void Run() {
            GameOptions.PauseGame();
        }

        public override string ToString() {
            return "PauseGameCommand";
        }
    }
}