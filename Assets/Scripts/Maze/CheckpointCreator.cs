using UnityEngine;
using UnityEditor;
using Assets.Scripts.Commands;

namespace Assets.Scripts.Maze {
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
            float triggerXPosition = WallWidth / 2 + WallThickness / 2;
            float triggerYPosition = WallWidth / 2;
            float triggerZPosition = 0.0f;
            GameObject triggerObject = ObjectFactory.CreateGameObject("StartTrigger");
            triggerObject.transform.position = new Vector3(triggerXPosition, triggerYPosition, triggerZPosition);
            triggerObject.AddComponent<BeginTimerCommand>();
            triggerObject.AddComponent<BeginTimerTrigger>();
            triggerObject.AddComponent<BoxCollider>();

            Collider colliderComponent = triggerObject.GetComponent<BoxCollider>();
            colliderComponent.isTrigger = true;
            colliderComponent.transform.localScale = new Vector3(WallWidth, WallWidth, 1.0f);
            return triggerObject;
        }

        private GameObject CreateEndTrigger() {
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
            colliderComponent.transform.localScale = new Vector3(1.0f, WallWidth, WallWidth);
            return triggerObject;
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
