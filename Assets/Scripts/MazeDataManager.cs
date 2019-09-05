using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts.Maze;

public class MazeDataManager : MonoBehaviour {
    public MazeData MazeData;
    public InputField Width;
    public InputField Height;

    private void Start() {
        MazeData = new MazeData();
    }

    public void OnEndEdit(string value) {
        if (value == "") {
            Debug.Log("You must enter a valid whole number.");
        }
    }

    public MazeData GetMazeOptions() {
        int width = int.Parse(Width.text);
        int height = int.Parse(Height.text);

        MazeData = new MazeData {
            CellSideLength = 10.0f,
            Width = width,
            Height = height,
            CellWallThickness = 0.1f
        };

        return MazeData;
    }
}
