using UnityEngine;

namespace Assets.Scripts.Maze {
    public class MazeDrawer {
        private int MazeWidth { get; set; }
        private int MazeHeight { get; set; }
        private Cell[,] Maze { get; set; }  // row x col
        private float WallWidth { get; set; }
        private float WallThickness { get; set; }

        public MazeDrawer(MazeData mazeData) {
            MazeWidth = mazeData.Width;
            MazeHeight = mazeData.Height;
            Maze = mazeData.Maze;
            WallWidth = mazeData.CellSize;
            WallThickness = mazeData.CellWallThickness;
        }

        public void DrawMaze() {
            if (MazeWidth > 0 && MazeHeight > 0) {
                DrawVerticalWalls();
                DrawHorizontalWalls();
            }
        }

        private void DrawVerticalWalls() {
            GameObject template = CreateVerticalTemplateWall();

            for (int row = 0; row < MazeHeight; row++) {
                for (int col = 0; col < MazeWidth; col++) {
                    DrawVerticalWall(row, col, template);
                }
            }

            template.SetActive(false);
        }

        private void DrawHorizontalWalls() {
            GameObject template = CreateHorizontalTemplateWall();

            for (int row = 0; row < MazeHeight; row++) {
                for (int col = 0; col < MazeWidth; col++) {
                    DrawHorizontalWall(row, col, template);
                }
            }

            template.SetActive(false);
        }

        private void DrawVerticalWall(int row, int col, GameObject template) {
            if (AtLeftEdge(row, col)) {
                DrawLeftEdge(row, template);
            }
            if (ShouldDrawRightWall(row, col)) {
                DrawRightWall(row, col, template);
            }
        }

        private void DrawHorizontalWall(int row, int col, GameObject template) {
            if (AtTopRow(row)) {
                DrawTopWall(col, template);
            }
            if (ShouldDrawBottomWall(row, col)) {
                DrawBottomWall(row, col, template);
            }
        }

        private GameObject CreateVerticalTemplateWall() {
            float totalWidth = WallWidth + 2 * WallThickness;
            float cellHeight = WallWidth; // Change later?

            float xPos = (cellHeight + WallThickness) / 2;
            float yPos = cellHeight / 2;
            float zPos = 0.0f;
            Vector3 position = new Vector3(xPos, yPos, zPos);
            Quaternion rotation = new Quaternion();

            GameObject exampleWall = GameObject.CreatePrimitive(PrimitiveType.Cube);

            BoxCollider boxCollider = exampleWall.GetComponent<BoxCollider>();
            boxCollider.size = new Vector3(1.05f, 5.0f, 10.0f);

            exampleWall.isStatic = true;
            GameObject templateWall = GameObject.Instantiate(exampleWall, position, rotation);
            templateWall.name = "Vertical Template";
            templateWall.transform.localScale = new Vector3(totalWidth, cellHeight, WallThickness);

            exampleWall.SetActive(false);
            return templateWall;
        }

        private GameObject CreateHorizontalTemplateWall() {
            float totalWidth = WallWidth + 2 * WallThickness;
            float cellHeight = WallWidth; // Change later?

            float xPos = 0.0f;
            float yPos = cellHeight / 2;
            float zPos = (cellHeight + WallThickness) / 2;
            Vector3 position = new Vector3(xPos, yPos, zPos);
            Quaternion rotation = new Quaternion();

            GameObject exampleWall = GameObject.CreatePrimitive(PrimitiveType.Cube);

            BoxCollider boxCollider = exampleWall.GetComponent<BoxCollider>();
            boxCollider.size = new Vector3(10.0f, 5.0f, 1.05f);

            exampleWall.isStatic = true;
            GameObject templateWall = GameObject.Instantiate(exampleWall, position, rotation);
            templateWall.name = "Horizontal Template";

            templateWall.transform.localScale = new Vector3(WallThickness, cellHeight, totalWidth);

            exampleWall.SetActive(false);
            return templateWall;
        }

        private void DrawTopWall(int col, GameObject templateWall) {
            float xPos = templateWall.transform.position.x;
            float yPos = templateWall.transform.position.y;
            float zPos = col * (WallWidth + WallThickness) + templateWall.transform.position.z;
            Vector3 wallPosition = new Vector3(xPos, yPos, zPos);
            Quaternion wallRotation = templateWall.transform.rotation;
            GameObject wall = GameObject.Instantiate(templateWall, wallPosition, wallRotation);
        }

        private void DrawBottomWall(int row, int col, GameObject templateWall) {
            float xPos = (row + 1) * (WallWidth + WallThickness) + templateWall.transform.position.x;
            float yPos = templateWall.transform.position.y;
            float zPos = col * (WallWidth + WallThickness) + templateWall.transform.position.z;
            Vector3 wallPosition = new Vector3(xPos, yPos, zPos);
            Quaternion wallRotation = templateWall.transform.rotation;
            GameObject wall = GameObject.Instantiate(templateWall, wallPosition, wallRotation);
        }

        private void DrawLeftEdge(int row, GameObject templateWall) {
            float xPos = row * (WallWidth + WallThickness) + templateWall.transform.position.x;
            float yPos = templateWall.transform.position.y;
            float zPos = templateWall.transform.position.z;
            Vector3 wallPosition = new Vector3(xPos, yPos, zPos);
            Quaternion wallRotation = templateWall.transform.rotation;
            GameObject wall = GameObject.Instantiate(templateWall, wallPosition, wallRotation);
        }

        private void DrawRightWall(int row, int col, GameObject templateWall) {
            float xPos = row * (WallWidth + WallThickness) + templateWall.transform.position.x;
            float yPos = templateWall.transform.position.y;
            float zPos = (col + 1) * (WallWidth + WallThickness) + templateWall.transform.position.z;
            Vector3 wallPosition = new Vector3(xPos, yPos, zPos);
            Quaternion wallRotation = templateWall.transform.rotation;
            GameObject wall = GameObject.Instantiate(templateWall, wallPosition, wallRotation);
        }

        private bool AtLeftEdge(int row, int col) {
            return (col == 0 && row != 0);
        }

        private bool AtTopRow(int row) {
            return row == 0;
        }

        private bool ShouldDrawRightWall(int row, int col) {
            return Maze[row, col].RightWall;
        }

        private bool ShouldDrawBottomWall(int row, int col) {
            return Maze[row, col].BottomWall;
        }
    }
}
