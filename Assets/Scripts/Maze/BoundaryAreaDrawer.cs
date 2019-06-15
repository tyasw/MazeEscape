using UnityEngine;
using UnityEditor;

namespace Assets.Scripts.Maze {
    public class BoundaryAreaDrawer {
        private float WallWidth { get; set; }
        private float WallThickness { get; set; }
        private float DistanceFromEntrance { get; set; }
        private float BoundaryWallThickness { get; set; }

        public BoundaryAreaDrawer(MazeData mazeData) {
            this.WallWidth = mazeData.CellSize;
            this.WallThickness = mazeData.CellWallThickness;
            this.DistanceFromEntrance = 15.0f;
            this.BoundaryWallThickness = 2.0f;
        }

        public void CreateBoundaryAreas() {
            DrawEntryBoundaryArea();
        }

        private void DrawEntryBoundaryArea() {
            GameObject boundaryObjects = ObjectFactory.CreateGameObject("BoundaryObjects");

            GameObject wallOne = CreateEntryBoundaryWallOne();
            GameObject wallTwo = CreateEntryBoundaryWallTwo();
            GameObject wallThree = CreateEntryBoundaryWallThree();

            wallOne.transform.parent = boundaryObjects.transform;
            wallTwo.transform.parent = boundaryObjects.transform;
            wallThree.transform.parent = boundaryObjects.transform;

            boundaryObjects.transform.position = new Vector3(-1.95f, 0.0f, -0.05f);
        }

        private GameObject CreateEntryBoundaryWallOne() {
            GameObject wallOne = ObjectFactory.CreateGameObject("EntryBoundaryWallOne");
            float wallOneScaleX = BoundaryWallThickness;
            float wallOneScaleY = WallWidth * 2.0f;
            float wallOneScaleZ = DistanceFromEntrance + BoundaryWallThickness;
            wallOne.transform.localScale = new Vector3(wallOneScaleX, wallOneScaleY, wallOneScaleZ);
            wallOne.transform.localPosition = new Vector3(BoundaryWallThickness / 2.0f, 0.0f, wallOneScaleZ / -2.0f);
            wallOne = AddCollider(wallOne);

            return wallOne;
        }

        private GameObject CreateEntryBoundaryWallTwo() {
            GameObject wallTwo = ObjectFactory.CreateGameObject("EntryBoundaryWallTwo");
            float wallTwoScaleX = WallWidth + 2.0f * BoundaryWallThickness;
            float wallTwoScaleY = WallWidth * 2.0f;
            float wallTwoScaleZ = BoundaryWallThickness;
            wallTwo.transform.localScale = new Vector3(wallTwoScaleX, wallTwoScaleY, wallTwoScaleZ);
            wallTwo.transform.localPosition = new Vector3(wallTwoScaleX / 2.0f, 0.0f, -(DistanceFromEntrance + (BoundaryWallThickness / 2.0f)));
            wallTwo = AddCollider(wallTwo);

            return wallTwo;
        }

        private GameObject CreateEntryBoundaryWallThree() {
            GameObject wallThree = ObjectFactory.CreateGameObject("EntryBoundaryWallThree");
            float wallThreeScaleX = BoundaryWallThickness;
            float wallThreeScaleY = WallWidth * 2.0f;
            float wallThreeScaleZ = DistanceFromEntrance + BoundaryWallThickness;
            wallThree.transform.localScale = new Vector3(wallThreeScaleX, wallThreeScaleY, wallThreeScaleZ);
            wallThree.transform.localPosition = new Vector3(WallWidth + 1.5f * BoundaryWallThickness, 0.0f, wallThreeScaleZ / -2.0f);
            wallThree = AddCollider(wallThree);

            return wallThree;
        }

        private GameObject AddCollider(GameObject wall) {
            wall.AddComponent<BoxCollider>();
            float xScale = wall.transform.localScale.x;
            float yScale = wall.transform.localScale.y;
            float zScale = wall.transform.localScale.z;
            Collider collider = wall.GetComponent<BoxCollider>();
            collider.isTrigger = false;
            collider.transform.localScale = new Vector3(xScale, yScale, zScale);

            return wall;
        }
    }
}
