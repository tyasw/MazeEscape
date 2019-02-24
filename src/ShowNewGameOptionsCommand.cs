/** StartNewGameCommand.cs
 * 
 * Show the options for starting a game.
 */
namespace MazeEscape.src {
    public class ShowNewGameOptionsCommand : Command {
        private GameController GameController { get; set; }

        public ShowNewGameOptionsCommand(GameController gameController) {
            GameController = gameController;
        }

        public void Run() {
            GameController.ShowGameOptions();
        }
    }
}
