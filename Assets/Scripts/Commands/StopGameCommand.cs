namespace Assets.Scripts.Commands {
    public class StopGameCommand : Command {
        private UnityHandler GameOptions { get; set; }

        public StopGameCommand(UnityHandler gameOptions) {
            GameOptions = gameOptions;
        }

        public void Run() {
            GameOptions.StopGame();
        }
    }
}