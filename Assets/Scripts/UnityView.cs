using UnityEngine;
using Assets.Scripts.Maze;

public class UnityView : MonoBehaviour, GameView {
    public ClassFactory ClassFactory { get; set; }
    public MazeData MazeData { get; set; }
    public GameModel GameModel { get; set; }

    void Awake() {
        ClassFactory = ClassFactory.GetInstance();
        GameModel = ClassFactory.GetGameModel();
        MazeData = ClassFactory.GetMazeData();
    }

    public void DrawWorld() {
        //...
        DrawMaze();
    }

    public void DrawMaze() {
        DrawMazeWalls();
        DrawEntryBoundaryArea();
        CreateStartAndEndTriggers();
    }

    private void DrawMazeWalls() {
        MazeDrawer mazeDrawer = new MazeDrawer(MazeData);
        mazeDrawer.DrawMaze();
    }

    private void DrawEntryBoundaryArea() {
        BoundaryAreaDrawer boundaryAreaDrawer = new BoundaryAreaDrawer(MazeData);
        boundaryAreaDrawer.CreateBoundaryAreas();
    }

    private void CreateStartAndEndTriggers() {
        CheckpointCreator checkpointCreator = new CheckpointCreator(MazeData);
        checkpointCreator.CreateCheckpoints();
    }
}