using System.Collections.Generic;

public class MazeData {
    public int Width { get; set; }
    public int Height { get; set; }
    public float CellSize { get; set; }
    public float CellWallThickness { get; set; }
    public List<Cell> Cells { get; set; }
    public Cell[,] Maze { get; set; }   // row x col

    private static MazeData MazeDataInstance = null;

    private MazeData() {

    }

    public static MazeData GetInstance() {
        if (MazeDataInstance == null) {
            MazeDataInstance = new MazeData();
        }
        return MazeDataInstance;
    }
}