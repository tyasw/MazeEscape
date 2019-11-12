using UnityEngine;
using Assets.Scripts.Maze;

/*
 * Stores the data and logic related to the game. This component shuold
 * be attached to the GameObject that has a UnityController attached to it.
 */
public class GameModel : MonoBehaviour {
    public GameState GameState { get; set; }

    private void Awake() {
        GameState = new GameState();
    }

    public void BeginGameWithOptionsApplied() {
        MazeData mazeData = GetGameOptions();
        GameState.MazeModel.MazeData = mazeData;
        MazeController mazeController = new MazeController(GameState.MazeModel);
        mazeController.CreateMaze();
    }

    private MazeData GetGameOptions() {
        GameObject gameDataGameObject = GameObject.FindGameObjectWithTag("GameData");
        GameModel gameModel = gameDataGameObject.gameObject.GetComponent<GameModel>();
        return gameModel.GameState.MazeModel.MazeData;
    }
}

public class GameState {
    public GameData GameData { get; set; } = new GameData();
    public MazeModel MazeModel { get; set; } = new MazeModel(new MazeData());
}
