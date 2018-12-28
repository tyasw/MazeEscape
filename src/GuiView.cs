using System;

/** GuiView.cs
 * 
 * Handles the input/output of the MazeTest program.
 */
namespace MazeEscape.src
{
    public class GuiView : GameView
    {
        public GameModel GameModel { get; set; }
        public MazeTransformer MazeTransformer { get; set; }
        public int MazeWidth { get; set; }
        public int MazeHeight { get; set; }

        private Cell[,] Maze { get; set; }  // row x col

        public GuiView(GameModel gameModel)
        {
            GameModel = gameModel;
            MazeTransformer = new MazeTransformer(GameModel.MazeModel);
            MazeWidth = GameModel.GetMazeWidth();
            MazeHeight = GameModel.GetMazeHeight();
        }

        public void ShowMaze()
        {
            MazeWidth = GameModel.GetMazeWidth();
            MazeHeight = GameModel.GetMazeHeight();
            Maze = MazeTransformer.CreateMazeMatrix();
            DrawMazeWalls();
        }

        private void DrawMazeWalls()
        {
            throw new NotImplementedException();
        }
    }
}
