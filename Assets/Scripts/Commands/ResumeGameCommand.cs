namespace Assets.Scripts.Commands {
    public class ResumeGameCommand : Command {
        private UnityHandler GameOptions { get; set; }

        public ResumeGameCommand(UnityHandler gameOptions) {
            GameOptions = gameOptions;
        }

        public void Run() {
            GameOptions.ResumeGame();
        }
    }
}
