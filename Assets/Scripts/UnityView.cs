using UnityEngine;
using Assets.Scripts.Maze;

public class UnityView : MonoBehaviour {
    public MazeData MazeData { get; set; }
    public GameModel GameModel;

    void Awake() {
        GameModel = GetComponent<GameModel>();
    }

    private void Start() {
        MazeData = GameModel.MazeModel.MazeData;
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