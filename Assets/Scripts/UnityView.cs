using UnityEngine;
using Assets.Scripts.Maze;

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
        MazeDrawer mazeDrawer = new MazeDrawer(MazeData);
        mazeDrawer.DrawMaze();
    }
}