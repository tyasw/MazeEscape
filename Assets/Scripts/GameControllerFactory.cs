using UnityEngine;

public class GameControllerFactory : MonoBehaviour {
    private static string GameControllerName { get; set; }

    public GameControllerFactory(string gameControllerName) {
        GameControllerName = gameControllerName;
    }

    public static GameController GetInstance() {
        GameController gameController;
        GameModel gameModel = new GameModel();
        GameView gameView;
        CommandParser commandParser = new CommandParser();
        CommandRunner commandRunner = new CommandRunner();
        GameOptions gameOptions;
        switch (GameControllerName) {
            case "UnityController":
                gameView = new UnityView(gameModel);
                gameOptions = new UnityOptions();
                gameController = new UnityController(gameModel, gameView, commandParser, commandRunner, gameOptions);
                break;
            default:
                gameController = null;
                break;

        }
        return gameController;
    }
}
