using UnityEngine;

public class UnityView : MonoBehaviour, GameView {
    public GameModel GameModel { get; set; }
    public MazeModel MazeModel { get; set; }
    public int MazeWidth { get; set; }
    public int MazeHeight { get; set; }

    private Cell[,] Maze { get; set; }  // row x col
    private MenuView MenuView { get; set; }

    void Start() {
        UnityController gameController = GetComponent<UnityController>();
        GameModel = GameModel.GetInstance();
        MazeModel = GameModel.MazeModel;
        Maze = new Cell[0, 0];
        MazeWidth = MazeModel.Width;
        MazeHeight = MazeModel.Height;
        MenuView = GetComponent<MenuView>();    // Change later to access dynamically?
    }

    public void DrawWorld() {
        //...
        DrawMaze();
    }

    public void DrawMaze() {
        MazeWidth = MazeModel.Width;
        MazeHeight = MazeModel.Height;
        Maze = MazeModel.Maze;
        float wallWidth = MazeModel.CellSize;
        float wallThickness = MazeModel.CellWallThickness;
        MazeDrawer mazeDrawer = new MazeDrawer(MazeWidth, MazeHeight, Maze, wallWidth, wallThickness);
        mazeDrawer.DrawMaze();
    }
}