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
        DrawBoundaryAreas();
        CreateStartAndEndTriggers();
    }

    private void DrawMazeWalls() {
        MazeDrawer mazeDrawer = new MazeDrawer(MazeData);
        mazeDrawer.DrawMaze();
    }

    private void DrawBoundaryAreas() {
        DrawEntryBoundaryArea();
        DrawExitBoundaryArea();
    }

    private void DrawEntryBoundaryArea() {
        GameObject wallOne = CreateBoundaryWall(1.0f, MazeData.CellSize, MazeData.CellSize * 2);
        wallOne.name = "EntryBoundaryWallOne";
        float wallOneXPos = wallOne.transform.position.x - 0.5f;
        float wallOneYPos = wallOne.transform.position.y;
        float wallOneZPos = wallOne.transform.position.z - 5.05f;
        wallOne.transform.position = new Vector3(wallOneXPos, wallOneYPos, wallOneZPos);
        GameObject wallTwo = CreateBoundaryWall(1.0f, MazeData.CellSize, MazeData.CellSize * 2);
        wallTwo.name = "EntryBoundaryWallTwo";
        float wallTwoXPos = wallTwo.transform.position.x + 10.6f;
        float wallTwoYPos = wallTwo.transform.position.y;
        float wallTwoZPos = wallTwo.transform.position.z - 5.05f;
        wallTwo.transform.position = new Vector3(wallTwoXPos, wallTwoYPos, wallTwoZPos);
        GameObject wallThree = CreateBoundaryWall(MazeData.CellSize + 2.2f, MazeData.CellSize, 1.0f);
        wallThree.name = "EntryBoundaryWallThree";
        float wallThreeXPos = wallThree.transform.position.x + 5.1f;
        float wallThreeYPos = wallThree.transform.position.y;
        float wallThreeZPos = wallThree.transform.position.z - 15.55f;
        wallThree.transform.position = new Vector3(wallThreeXPos, wallThreeYPos, wallThreeZPos);
    }

    private void DrawExitBoundaryArea() {

    }

    private GameObject CreateBoundaryWall(float xScale, float yScale, float zScale) {
        float WallWidth = MazeData.CellSize;
        float WallThickness = MazeData.CellWallThickness;

        float totalWidth = WallWidth + 2 * WallThickness;
        float cellHeight = WallWidth; // Change later?

        float xPos = 0.0f;
        float yPos = cellHeight / 2;
        float zPos = -1 * (WallWidth + WallThickness) + (cellHeight + WallThickness) / 2;

        GameObject entryBoundaryArea = ObjectFactory.CreateGameObject("EntryBoundaryArea");
        entryBoundaryArea.transform.position = new Vector3(xPos, yPos, zPos);
        entryBoundaryArea.transform.localScale = new Vector3(xScale, yScale, zScale);
        entryBoundaryArea = AddColliderToBoundaryWall(entryBoundaryArea);
        return entryBoundaryArea;
    }

    private GameObject AddColliderToBoundaryWall(GameObject wall) {
        wall.AddComponent<BoxCollider>();
        float xScale = wall.transform.localScale.x + 0.1f;
        float yScale = wall.transform.localScale.y;
        float zScale = wall.transform.localScale.z + 0.1f;
        Collider collider = wall.GetComponent<BoxCollider>();
        collider.isTrigger = false;
        collider.transform.localScale = new Vector3(xScale, yScale, zScale);

        return wall;
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