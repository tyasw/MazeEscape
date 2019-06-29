using UnityEngine;
using Assets.Scripts.Commands;

namespace Assets.Scripts.Maze {
    /*
     * Create triggers in the game, such as the trigger that starts the
     * game timer, and the trigger that displays the win screen.
     */
    public class CheckpointCreator {
        private float WallWidth { get; set; }
        private float WallThickness { get; set; }
        private int MazeHeight { get; set; }
        private int MazeWidth { get; set; }

        public CheckpointCreator(MazeData mazeData) {
            this.WallWidth = mazeData.CellSize;
            this.WallThickness = mazeData.CellWallThickness;
            this.MazeHeight = mazeData.Height;
            this.MazeWidth = mazeData.Width;
        }

        public void CreateCheckpoints() {
            GameObject startTrigger = CreateStartTrigger();
            GameObject endTrigger = CreateEndTrigger();
        }

        private GameObject CreateStartTrigger() {
            float triggerXPosition = CalculateStartTriggerXPosition();
            float triggerYPosition = CalculateStartTriggerYPosition();
            float triggerZPosition = CalculateStartTriggerZPosition();
            GameObject triggerObject = new GameObject("StartTrigger");
            triggerObject.transform.position = new Vector3(triggerXPosition, triggerYPosition, triggerZPosition);
            triggerObject.transform.localScale = new Vector3(WallWidth, WallWidth, 1.0f);
            triggerObject = AddStartTriggerComponents(triggerObject);
            return triggerObject;
        }

        private GameObject CreateEndTrigger() {
            float triggerXPosition = CalculateEndTriggerXPosition();
            float triggerYPosition = CalculateEndTriggerYPosition();
            float triggerZPosition = CalculateEndTriggerZPosition();
            GameObject triggerObject = new GameObject("EndTrigger");
            triggerObject.transform.position = new Vector3(triggerXPosition, triggerYPosition, triggerZPosition);
            triggerObject.transform.localScale = new Vector3(1.0f, WallWidth, WallWidth);
            triggerObject = AddEndTriggerComponents(triggerObject);
            return triggerObject;
        }

        private GameObject AddStartTriggerComponents(GameObject gameObject) {
            gameObject.AddComponent<BeginTimerCommand>();
            gameObject.AddComponent<BeginTimerTrigger>();
            gameObject = AddCollider(gameObject);

            return gameObject;
        }

        private GameObject AddEndTriggerComponents(GameObject gameObject) {
            gameObject.AddComponent<FinishGameCommand>();
            gameObject.AddComponent<WinTrigger>();
            gameObject = AddCollider(gameObject);
            return gameObject;
        }

        private GameObject AddCollider(GameObject gameObject) {
            gameObject.AddComponent<BoxCollider>();
            float xScale = gameObject.transform.localScale.x;
            float yScale = gameObject.transform.localScale.y;
            float zScale = gameObject.transform.localScale.z;
            Collider collider = gameObject.GetComponent<BoxCollider>();
            collider.isTrigger = true;
            collider.transform.localScale = new Vector3(xScale, yScale, zScale);

            return gameObject;
        }

        private float CalculateStartTriggerXPosition() {
            return WallWidth / 2 + WallThickness / 2;
        }

        private float CalculateStartTriggerYPosition() {
            return WallWidth / 2;
        }

        private float CalculateStartTriggerZPosition() {
            return 0.0f;
        }

        private float CalculateEndTriggerXPosition() {
            int mazeHeight = MazeHeight;
            float cellSize = WallWidth;
            float cellWallThickness = WallThickness;
            return (cellSize + cellWallThickness) * mazeHeight;
        }

        private float CalculateEndTriggerYPosition() {
            return WallWidth / 2;
        }

        private float CalculateEndTriggerZPosition() {
            int mazeWidth = MazeWidth;
            float cellSize = WallWidth;
            float cellWallThickness = WallThickness;
            return (cellSize + cellWallThickness) * (mazeWidth - 1) + cellSize / 2 + cellWallThickness / 2;
        }
    }
}
