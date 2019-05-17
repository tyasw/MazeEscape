using UnityEngine;
using UnityEditor;
using Assets.Scripts.Maze;
using Assets.Scripts.Commands;

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
        DrawMazeWalls();
        CreateStartAndEndTriggers();
    }

    private void DrawMazeWalls() {
        MazeDrawer mazeDrawer = new MazeDrawer(MazeData);
        mazeDrawer.DrawMaze();
    }

    private void CreateStartAndEndTriggers() {
        CreateStartTrigger();
        CreateEndTrigger();
    }

    private Collider CreateStartTrigger() {
        float triggerXPosition = MazeData.CellSize / 2 + MazeData.CellWallThickness / 2;
        float triggerYPosition = MazeData.CellSize / 2;
        float triggerZPosition = 0.0f;
        GameObject triggerObject = ObjectFactory.CreateGameObject("StartTrigger");
        triggerObject.transform.position = new Vector3(triggerXPosition, triggerYPosition, triggerZPosition);
        triggerObject.AddComponent<BeginTimerCommand>();
        triggerObject.AddComponent<BeginTimerTrigger>();
        triggerObject.AddComponent<BoxCollider>();
        Collider colliderComponent = triggerObject.GetComponent<BoxCollider>();
        colliderComponent.isTrigger = true;
        colliderComponent.transform.localScale = new Vector3(MazeData.CellSize, MazeData.CellSize, 1.0f);
        return colliderComponent;
    }

    private Collider CreateEndTrigger() {
        float triggerXPosition = CalculateEndTriggerXPosition();
        float triggerYPosition = CalculateEndTriggerYPosition();
        float triggerZPosition = CalculateEndTriggerZPosition();
        GameObject triggerObject = ObjectFactory.CreateGameObject("EndTrigger");
        triggerObject.transform.position = new Vector3(triggerXPosition, triggerYPosition, triggerZPosition);
        triggerObject.AddComponent<FinishGameCommand>();
        triggerObject.AddComponent<WinTrigger>();
        triggerObject.AddComponent<BoxCollider>();
        Collider colliderComponent = triggerObject.GetComponent<BoxCollider>();
        colliderComponent.isTrigger = true;
        colliderComponent.transform.localScale = new Vector3(1.0f, MazeData.CellSize, MazeData.CellSize);
        return colliderComponent;
    }

    private float CalculateEndTriggerXPosition() {
        int mazeHeight = MazeData.Height;
        float cellSize = MazeData.CellSize;
        float cellWallThickness = MazeData.CellWallThickness;
        return (cellSize + cellWallThickness) * mazeHeight;
    }

    private float CalculateEndTriggerYPosition() {
        return MazeData.CellSize / 2;
    }

    private float CalculateEndTriggerZPosition() {
        int mazeWidth = MazeData.Width;
        float cellSize = MazeData.CellSize;
        float cellWallThickness = MazeData.CellWallThickness;
        return (cellSize + cellWallThickness) * (mazeWidth - 1) + cellSize / 2 + cellWallThickness / 2;
    }
}