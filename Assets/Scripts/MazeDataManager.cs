using UnityEngine;
using Assets.Scripts.Maze;

public class MazeDataManager : MonoBehaviour {
    public MazeData MazeData;

    private void Start() {
        MazeData = new MazeData();
        MazeData.CellSideLength = 10.0f;
        MazeData.Width = 5;
        MazeData.Height = 5;
        MazeData.CellWallThickness = 0.1f;
    }
}
