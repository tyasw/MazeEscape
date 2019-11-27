using Assets.Scripts.Maze;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI {
    public class NewGameController : MonoBehaviour {
        public Text Width;
        public Text Height;
        public ErrorView ErrorView;

        public bool CanStartNewGame() {
            List<string> validationMessages = GetErrors();
            ErrorView.SetErrors(validationMessages);
            return validationMessages.Count == 0;
        }

        public void setUpGame() {
            int width = int.Parse(Width.text);
            int height = int.Parse(Height.text);
            SetMazeOptions(width, height, 10.0f, 0.1f);
        }

        private void SetMazeOptions(int width, int height, float cellSideLength, float cellWallThickness) {
            MazeData mazeData = new MazeData {
                CellSideLength = cellSideLength,
                Width = width,
                Height = height,
                CellWallThickness = cellWallThickness
            };

            GameObject gameDataGameObject = GameObject.FindGameObjectWithTag("GameData");
            GameModel gameModel = gameDataGameObject.gameObject.GetComponent<GameModel>();
            gameModel.MazeData = mazeData;
        }

        private List<string> GetErrors() {
            List<string> validationMessages = new List<string>();

            if (string.IsNullOrEmpty(Width.text)) {
                validationMessages.Add("Width must be filled in");
            }

            if (int.TryParse(Width.text, out int widthValue) && widthValue < 0) {
                validationMessages.Add("Width must be non-negative.");
            }

            if (string.IsNullOrEmpty(Height.text)) {
                validationMessages.Add("Height must be filled in");
            }

            if (int.TryParse(Height.text, out int heightValue) && heightValue < 0) {
                validationMessages.Add("Height must be non-negative.");
            }

            return validationMessages;
        }
    }
}
