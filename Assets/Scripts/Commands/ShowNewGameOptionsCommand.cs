namespace Assets.Scripts.Commands {
    public class ShowNewGameOptionsCommand : Command {
        private GameOptions GameOptions { get; set; }

        public ShowNewGameOptionsCommand(GameOptions gameOptions) {
            GameOptions = gameOptions;
        }

        public void Run() {
            GameOptions.ShowGameOptions();
        }
    }
}
