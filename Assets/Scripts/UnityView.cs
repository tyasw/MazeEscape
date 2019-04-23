using UnityEngine;

public class UnityView : MonoBehaviour, GameView {
    public MazeData MazeData { get; set; }
    public GameModel GameModel { get; set; }

    private MenuView MenuView { get; set; }

    void Start() {
        MazeData = MazeData.GetInstance();

        UnityController gameController = GetComponent<UnityController>();
        GameModel = GameModel.GetInstance();


        MenuView = GetComponent<MenuView>();    // Change later to access dynamically?
    }

    public void DrawWorld() {
        //...
        DrawMaze();
    }

    public void DrawMaze() {
        int mazeWidth = MazeData.Width;
        int mazeHeight = MazeData.Height;
        Cell[,] maze = MazeData.Maze;
        float wallWidth = MazeData.CellSize;
        float wallThickness = MazeData.CellWallThickness;
        MazeDrawer mazeDrawer = new MazeDrawer(mazeWidth, mazeHeight, maze, wallWidth, wallThickness);
        mazeDrawer.DrawMaze();
    }
}