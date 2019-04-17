namespace Assets.Scripts.Commands {
    public class ShowNewGameOptionsCommand : Command {
        private UnityHandler GameOptions { get; set; }

        public ShowNewGameOptionsCommand(UnityHandler gameOptions) {
            GameOptions = gameOptions;
        }

        public void Run() {
            GameOptions.ShowGameOptions();
        }
    }
}
