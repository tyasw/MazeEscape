using UnityEngine;
using UnityEditor;

namespace Assets.Scripts.Maze {
    public class BoundaryAreaDrawer {
        private float WallWidth { get; set; }
        private float WallThickness { get; set; }

        public BoundaryAreaDrawer(MazeData mazeData) {
            this.WallWidth = mazeData.CellSize;
            this.WallThickness = mazeData.CellWallThickness;
        }

        public void CreateBoundaryAreas() {
            DrawEntryBoundaryArea();
        }

        private void DrawEntryBoundaryArea() {
            float totalWidth = WallWidth + 2 * WallThickness;
            float cellHeight = WallWidth; // Change later?
            float xPos = 0.0f;
            float yPos = cellHeight / 2;
            float zPos = -1 * (WallWidth + WallThickness) + (cellHeight + WallThickness) / 2;

            GameObject wallOne = ObjectFactory.CreateGameObject("EntryBoundaryWallOne");
            wallOne.transform.position = new Vector3(xPos - 0.5f, yPos, zPos - 5.05f);
            wallOne.transform.localScale = new Vector3(1.0f, WallWidth, WallWidth * 2);
            wallOne = AddCollider(wallOne);

            GameObject wallTwo = ObjectFactory.CreateGameObject("EntryBoundaryWallTwo");
            wallTwo.transform.position = new Vector3(xPos + 10.6f, yPos, zPos - 5.05f);
            wallTwo.transform.localScale = new Vector3(1.0f, WallWidth, WallWidth * 2);
            wallTwo = AddCollider(wallTwo);

            GameObject wallThree = ObjectFactory.CreateGameObject("EntryBoundaryWallThree");
            wallThree.transform.position = new Vector3(xPos + 5.1f, yPos, zPos - 15.55f);
            wallThree.transform.localScale = new Vector3(WallWidth + 2.2f, WallWidth, 1.0f);
            wallThree = AddCollider(wallThree);
        }

        private GameObject AddCollider(GameObject wall) {
            wall.AddComponent<BoxCollider>();
            float xScale = wall.transform.localScale.x + 0.2f;
            float yScale = wall.transform.localScale.y * 3.0f;
            float zScale = wall.transform.localScale.z + 0.2f;
            Collider collider = wall.GetComponent<BoxCollider>();
            collider.isTrigger = false;
            collider.transform.localScale = new Vector3(xScale, yScale, zScale);

            return wall;
        }
    }
}
