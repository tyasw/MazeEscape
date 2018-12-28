using System;

/** TextView.cs
 * 
 * Handles the input/output of the MazeTest program.
 */
namespace MazeEscapeLibrary.src
{
    public class TextView : GameView
    {
        public GameModel GameModel { get; set; }
        public MazeTransformer MazeTransformer { get; set; }
        public int MazeWidth { get; set; }
        public int MazeHeight { get; set; }

        private Cell[,] Maze { get; set; }  // row x col

        public TextView(GameModel gameModel)
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
            if (MazeWidth > 0 && MazeHeight > 0)
            {
                DrawTopEdge();
                for (int row = 0; row < MazeHeight; row++)
                {
                    DrawLeftEdge(row);
                    DrawInteriorRow(row);
                }
            }
        }

        private void DrawTopEdge()
        {
            for (int col = 0; col < MazeWidth; col++)
            {
                Console.Write(" ");
                DrawHorizontalWall();
            }
            Console.WriteLine();
        }

        private void DrawBottomEdge()
        {
            for (int col = 0; col < MazeWidth; col++)
            {
                Console.Write(" ");
                DrawHorizontalWall();
            }
        }

        private void DrawLeftEdge(int row)
        {
            if (row != 0)
            {
                DrawVerticalWall();
            }
            else
            {
                Console.Write(" ");
            }
        }

        private void DrawInteriorRow(int row)
        {
            for (int col = 0; col < MazeWidth; col++)
            {
                if (Maze[row, col].BottomWall)
                {
                    DrawHorizontalWall();
                }
                else
                {
                    Console.Write(" ");
                }

                if (Maze[row, col].RightWall)
                {
                    DrawVerticalWall();
                }
                else
                {
                    Console.Write(" ");
                }
            }
            Console.WriteLine();
        }

        private void DrawVerticalWall()
        {
            Console.Write("|");
        }

        private void DrawHorizontalWall()
        {
            Console.Write("_");
        }
    }
}
