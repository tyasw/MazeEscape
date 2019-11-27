using UnityEngine;
using Assets.Scripts.Maze;

/*
 * Controls the drawing of objects in the scene. This includes both the maze
 * and the world around it. This component must be attached to the
 * UnityController in the scene.
 */
public class GameView : MonoBehaviour {
    public MazeData MazeData { get; set; }
    public GameModel GameModel;

    void Awake() {
        GameObject gameDataGameObject = GameObject.FindGameObjectWithTag("GameData");
        GameModel = gameDataGameObject.gameObject.GetComponent<GameModel>();
        MazeData = GameModel.MazeData;
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
        MazeDrawer mazeDrawer = new MazeDrawer(GameModel.MazeData);
        mazeDrawer.DrawMaze();
    }

    private void DrawEntryBoundaryArea() {
        BoundaryAreaDrawer boundaryAreaDrawer = new BoundaryAreaDrawer(GameModel.MazeData);
        boundaryAreaDrawer.CreateBoundaryAreas();
    }

    private void CreateStartAndEndTriggers() {
        CheckpointCreator checkpointCreator = new CheckpointCreator(GameModel.MazeData);
        checkpointCreator.CreateCheckpoints();
    }
}