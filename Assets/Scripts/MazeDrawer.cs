using UnityEngine;

public class MazeDrawer {
    public int MazeWidth { get; set; }
    public int MazeHeight { get; set; }

    private Cell[,] Maze { get; set; }  // row x col
    private Wall VerticalTemplate { get; set; }
    private Wall HorizontalTemplate { get; set; }
    private float WallWidth { get; set; }
    private float WallThickness { get; set; }

    public MazeDrawer(int mazeWidth, int mazeHeight, Cell[,] maze, float wallWidth, float wallThickness) {
        MazeWidth = mazeWidth;
        MazeHeight = mazeHeight;
        Maze = maze;
        WallWidth = wallWidth;
        WallThickness = wallThickness;
    }

    public void DrawMaze() {
        if (MazeWidth > 0 && MazeHeight > 0) {
            Wall verticalTemplateWall = CreateVerticalTemplateWall();
            Wall horizontalTemplateWall = CreateHorizontalTemplateWall();
            DrawWalls(verticalTemplateWall, horizontalTemplateWall);
            verticalTemplateWall.Instance.SetActive(false);
            horizontalTemplateWall.Instance.SetActive(false);
        }
    }

    private void DrawWalls(Wall verticalTemplate, Wall horizontalTemplate) {
        for (int row = 0; row < MazeHeight; row++) {
            for (int col = 0; col < MazeWidth; col++) {
                DrawWall(row, col, verticalTemplate, horizontalTemplate);
            }
        }
    }

    private void DrawWall(int row, int col, Wall verticalTemplate, Wall horizontalTemplate) {
        if (row == 0) {
            DrawTopWall(col, horizontalTemplate);
        }

        if (col == 0) {
            DrawLeftEdge(row, verticalTemplate);
        }

        if (Maze[row, col].RightWall) {
            DrawRightWall(row, col, verticalTemplate);
        }

        if (Maze[row, col].BottomWall) {
            DrawBottomWall(row, col, horizontalTemplate);
        }
    }

    private Wall CreateVerticalTemplateWall() {
        float totalWidth = WallWidth + 2 * WallThickness;
        float cellHeight = WallWidth; // Change later?

        GameObject exampleWall = GameObject.FindGameObjectWithTag("Wall");

        float xPos = (cellHeight + WallThickness) / 2;
        float yPos = cellHeight / 2;
        float zPos = 0.0f;
        Vector3 position = new Vector3(xPos, yPos, zPos);
        Quaternion rotation = exampleWall.transform.rotation;
        GameObject templateWall = GameObject.Instantiate(exampleWall, position, rotation);
        templateWall.name = "Vertical Template";

        templateWall.transform.localScale = new Vector3(totalWidth, cellHeight, WallThickness);
        Wall template = new Wall(WallThickness, WallWidth, templateWall);

        return template;
    }

    private Wall CreateHorizontalTemplateWall() {
        float totalWidth = WallWidth + 2 * WallThickness;
        float cellHeight = WallWidth; // Change later?

        GameObject exampleWall = GameObject.FindGameObjectWithTag("Wall");

        float xPos = 0.0f;
        float yPos = cellHeight / 2;
        float zPos = (cellHeight + WallThickness) / 2;
        Vector3 position = new Vector3(xPos, yPos, zPos);
        Quaternion rotation = exampleWall.transform.rotation;
        GameObject templateWall = GameObject.Instantiate(exampleWall, position, rotation);
        templateWall.name = "Horizontal Template";

        templateWall.transform.localScale = new Vector3(WallThickness, cellHeight, totalWidth);

        Wall template = new Wall(WallThickness, WallWidth, templateWall);

        return template;
    }

    private void DrawTopWall(int col, Wall horizontalTemplate) {
        GameObject horizontalWall = horizontalTemplate.Instance;

        float xPos = horizontalWall.transform.position.x;
        float yPos = horizontalWall.transform.position.y;
        float zPos = col * (WallWidth + WallThickness) + horizontalWall.transform.position.z;

        Vector3 wallPosition = new Vector3(xPos, yPos, zPos);
        Quaternion wallRotation = horizontalWall.transform.rotation;
        GameObject wall = GameObject.Instantiate(horizontalWall, wallPosition, wallRotation);
    }

    private void DrawBottomWall(int row, int col, Wall horizontalTemplate) {
        GameObject horizontalWall = horizontalTemplate.Instance;

        float xPos = (row + 1) * (WallWidth + WallThickness) + horizontalWall.transform.position.x;
        float yPos = horizontalWall.transform.position.y;
        float zPos = col * (WallWidth + WallThickness) + horizontalWall.transform.position.z;

        Vector3 wallPosition = new Vector3(xPos, yPos, zPos);
        Quaternion wallRotation = horizontalWall.transform.rotation;
        GameObject wall = GameObject.Instantiate(horizontalWall, wallPosition, wallRotation);
    }

    private void DrawLeftEdge(int row, Wall templateWall) {
        if (row != 0) {         // Leave upper right open for entrance
            GameObject template = templateWall.Instance;
            Quaternion wallRotation = template.transform.rotation;
            float xPos = row * (WallWidth + WallThickness) + template.transform.position.x;
            float yPos = template.transform.position.y;
            float zPos = template.transform.position.z;
            Vector3 wallPosition = new Vector3(xPos, yPos, zPos);
            GameObject wall = GameObject.Instantiate(template, wallPosition, wallRotation);
        }
    }

    private void DrawRightWall(int row, int col, Wall verticalTemplate) {
        GameObject verticalWall = verticalTemplate.Instance;

        float xPos = row * (WallWidth + WallThickness) + verticalWall.transform.position.x;
        float yPos = verticalWall.transform.position.y;
        float zPos = (col + 1) * (WallWidth + WallThickness) + verticalWall.transform.position.z;
        Vector3 wallPosition = new Vector3(xPos, yPos, zPos);
        Quaternion wallRotation = verticalWall.transform.rotation;
        GameObject wall = GameObject.Instantiate(verticalWall, wallPosition, wallRotation);
    }
}
