namespace Assets.Scripts.Commands {
    public class ResumeGameCommand : Command {
        private GameOptions GameOptions { get; set; }

        public ResumeGameCommand(GameOptions gameOptions) {
            GameOptions = gameOptions;
        }

        public void Run() {
            GameOptions.ResumeGame();
        }
    }
}
