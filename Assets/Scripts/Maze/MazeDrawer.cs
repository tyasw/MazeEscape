using UnityEngine;

namespace Assets.Scripts.Maze {
    public class MazeDrawer {
        private int MazeWidth { get; set; }
        private int MazeHeight { get; set; }
        private Cell[,] Maze { get; set; }  // row x col
        private GameObject VerticalTemplate { get; set; }
        private GameObject HorizontalTemplate { get; set; }
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
                GameObject verticalTemplateWall = CreateVerticalTemplateWall();
                GameObject horizontalTemplateWall = CreateHorizontalTemplateWall();
                DrawWalls(verticalTemplateWall, horizontalTemplateWall);
                verticalTemplateWall.SetActive(false);
                horizontalTemplateWall.SetActive(false);
            }
        }

        private void DrawWalls(GameObject verticalTemplate, GameObject horizontalTemplate) {
            for (int row = 0; row < MazeHeight; row++) {
                for (int col = 0; col < MazeWidth; col++) {
                    DrawWall(row, col, verticalTemplate, horizontalTemplate);
                }
            }
        }

        private void DrawWall(int row, int col, GameObject verticalTemplate, GameObject horizontalTemplate) {
            if (row == 0) {
                DrawTopWall(col, horizontalTemplate);
            }

            if (col == 0 && row != 0) {
                DrawLeftEdge(row, verticalTemplate);
            }

            if (Maze[row, col].RightWall) {
                DrawRightWall(row, col, verticalTemplate);
            }

            if (Maze[row, col].BottomWall) {
                DrawBottomWall(row, col, horizontalTemplate);
            }
        }

        private GameObject CreateVerticalTemplateWall() {
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

            return templateWall;
        }

        private GameObject CreateHorizontalTemplateWall() {
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

            return templateWall;
        }

        private void DrawTopWall(int col, GameObject horizontalTemplate) {
            float xPos = horizontalTemplate.transform.position.x;
            float yPos = horizontalTemplate.transform.position.y;
            float zPos = col * (WallWidth + WallThickness) + horizontalTemplate.transform.position.z;
            Vector3 wallPosition = new Vector3(xPos, yPos, zPos);
            Quaternion wallRotation = horizontalTemplate.transform.rotation;
            GameObject wall = GameObject.Instantiate(horizontalTemplate, wallPosition, wallRotation);
        }

        private void DrawBottomWall(int row, int col, GameObject horizontalTemplate) {
            float xPos = (row + 1) * (WallWidth + WallThickness) + horizontalTemplate.transform.position.x;
            float yPos = horizontalTemplate.transform.position.y;
            float zPos = col * (WallWidth + WallThickness) + horizontalTemplate.transform.position.z;
            Vector3 wallPosition = new Vector3(xPos, yPos, zPos);
            Quaternion wallRotation = horizontalTemplate.transform.rotation;
            GameObject wall = GameObject.Instantiate(horizontalTemplate, wallPosition, wallRotation);
        }

        private void DrawLeftEdge(int row, GameObject templateWall) {
            float xPos = row * (WallWidth + WallThickness) + templateWall.transform.position.x;
            float yPos = templateWall.transform.position.y;
            float zPos = templateWall.transform.position.z;
            Vector3 wallPosition = new Vector3(xPos, yPos, zPos);
            Quaternion wallRotation = templateWall.transform.rotation;
            GameObject wall = GameObject.Instantiate(templateWall, wallPosition, wallRotation);
        }

        private void DrawRightWall(int row, int col, GameObject verticalTemplate) {
            float xPos = row * (WallWidth + WallThickness) + verticalTemplate.transform.position.x;
            float yPos = verticalTemplate.transform.position.y;
            float zPos = (col + 1) * (WallWidth + WallThickness) + verticalTemplate.transform.position.z;
            Vector3 wallPosition = new Vector3(xPos, yPos, zPos);
            Quaternion wallRotation = verticalTemplate.transform.rotation;
            GameObject wall = GameObject.Instantiate(verticalTemplate, wallPosition, wallRotation);
        }
    }
}
