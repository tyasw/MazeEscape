using System;
using System.Collections.Generic;

/** MazeModel.cs
 * 
 * Holds the logic for creating the maze.
 */
namespace MazeEscapeLibrary.src
{ 
    public class MazeModel
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public float CellSize { get; set; }
        public float CellWallThickness { get; set; }
        public List<Cell> Cells { get; set; }
        public List<TwoTuple<Cell>> Walls { get; set; }

        private List<TwoTuple<Cell>> CellPairs { get; set; }
        private List<TwoTuple<Cell>> Doors { get; set; }

        public MazeModel()
        {
            Width = 0;
            Height = 0;
            CellSize = 0.0f;
            CellWallThickness = 0.0f;
            Cells = new List<Cell>();
            CellPairs = new List<TwoTuple<Cell>>();
            Doors = new List<TwoTuple<Cell>>();
            Walls = new List<TwoTuple<Cell>>();
        }

        public void CreateMaze()
        {
            SetupModel();

            while (CellPairs.Count > 0)
            {
                TwoTuple<Cell> cellPair = CellPairs[0];
                CellPairs.RemoveAt(0);

                Cell firstCell = cellPair.X;
                Cell secondCell = cellPair.Y;

                Tree<Cell> TreeOne = firstCell.TreeNodePointer;
                Tree<Cell> TreeTwo = secondCell.TreeNodePointer;

                if (!TreeOne.IsInSameTreeAs(TreeTwo))
                {
                    Doors.Add(cellPair);
                    TreeOne.MergeWith(TreeTwo);
                }
                else
                {
                    Walls.Add(cellPair);
                }
            }
        }

        private void SetupModel()
        {
            CreateCells();
            CreateCellPairs();
            CreateCellPartitions();
            RandomizeListOfCellPairs();
        }

        private void CreateCells()
        {
            for (int i = 0; i < (Width * Height); i++)
            {
                Cells.Add(new Cell(i, CellSize));
            }
        }

        // Assumes that cells have already been created
        private void CreateCellPairs()
        {
            for (int i = 0; i < (Width * Height); i++)
            {
                if ((i + 1) % Width != 0)
                {   // Not at far right edge
                    CellPairs.Add(new TwoTuple<Cell>(Cells[i], Cells[i + 1]));
                }
                if (!(((Height - 1) * Width) <= i && i < (Height * Width)))
                {   // Not at bottom edge
                    CellPairs.Add(new TwoTuple<Cell>(Cells[i], Cells[i + Width]));
                }
            }
        }

        private void CreateCellPartitions()
        {
            for (int i = 0; i < (Width * Height); i++)
            {
                Tree<Cell> tree = new Tree<Cell>(Cells[i]);
                Cells[i].TreeNodePointer = tree;
            }
        }

        // For each cell pair, swap with a pair at a random location
        private void RandomizeListOfCellPairs()
        {
            Random r = new Random();
            for (int i = 0; i < CellPairs.Count; i++)
            {
                int randomPosition = r.Next(CellPairs.Count);
                TwoTuple<Cell> firstPair = CellPairs[i];
                TwoTuple<Cell> secondPair = CellPairs[randomPosition];
                CellPairs[i] = secondPair;
                CellPairs[randomPosition] = firstPair;
            }
        }
    }
}
