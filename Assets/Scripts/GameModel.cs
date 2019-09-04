using UnityEngine;
using Assets.Scripts.Maze;

/*
 * Stores the data and logic related to the game. This component shuold
 * be attached to the GameObject that has a UnityController attached to it.
 */
public class GameModel : MonoBehaviour {
    public GameData GameData { get; set; }
    public MazeModel MazeModel { get; set; }

    private void Awake() {
        GameData = new GameData();
        MazeModel = new MazeModel(new MazeData());
    }

    public void BeginGameWithOptionsApplied() {
        GetGameOptions();
        MazeController mazeController = new MazeController(MazeModel);
        mazeController.CreateMaze();
    }

    // TODO: get the options from an options file
    private void GetGameOptions() {
        GameObject gameDataGameObject = GameObject.FindGameObjectWithTag("GameData");
        MazeDataManager mazeDataManager = gameDataGameObject.gameObject.GetComponent<MazeDataManager>();
        MazeData mazeData = mazeDataManager.MazeData;

        //MazeData mazeData = MazeModel.MazeData;
        mazeData.CellSideLength = 10.0f;
        mazeData.Width = 5;
        mazeData.Height = 5;
        mazeData.CellWallThickness = 0.1f;

        Debug.Log(mazeData.CellSideLength);
        Debug.Log(mazeData.Width);
        Debug.Log(mazeData.Height);
        Debug.Log(mazeData.CellWallThickness);

        MazeModel.MazeData = mazeData;
    }
}
