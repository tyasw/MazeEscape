namespace Assets.Scripts.Commands {
    public class BeginGameCommand : Command {
        public GameModel GameModel { get; set; }
        public GameView GameView { get; set; }

        public BeginGameCommand(GameModel gameModel, GameView gameView) {
            GameModel = gameModel;
            GameView = gameView;
        }

        public void Run() {
            GameModel.BeginGameWithOptionsApplied();
            GameView.DrawWorld();
        }

        public override string ToString() {
            return "BeginGameCommand";
        }
    }
}
