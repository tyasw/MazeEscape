namespace Assets.Scripts.Commands {
    public class PauseGameCommand : Command {
        private UnityHandler GameOptions { get; set; }

        public PauseGameCommand(UnityHandler gameOptions) {
            GameOptions = gameOptions;
        }

        public void Run() {
            GameOptions.PauseGame();
        }
    }
}