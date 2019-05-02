using UnityEngine;
using Assets.Scripts.Maze;

public class UnityView : MonoBehaviour, GameView {
    public ClassFactory ClassFactory { get; set; }
    public MazeData MazeData { get; set; }
    public GameModel GameModel { get; set; }

    private MenuView MenuView { get; set; }

    void Awake() {
        ClassFactory = ClassFactory.GetInstance();
        GameModel = ClassFactory.GetGameModel();
        MazeData = ClassFactory.GetMazeData();
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