using UnityEngine;
using Assets.Scripts.Maze;

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
        MazeData mazeData = MazeModel.MazeData;
        mazeData.CellSize = 10.0f;
        mazeData.Width = 5;
        mazeData.Height = 5;
        mazeData.CellWallThickness = 0.1f;
    }
}
