namespace Assets.Scripts.Commands {
    public class StopGameCommand : Command {
        private GameOptions GameOptions { get; set; }

        public StopGameCommand(GameOptions gameOptions) {
            GameOptions = gameOptions;
        }

        public void Run() {
            GameOptions.StopGame();
        }
    }
}