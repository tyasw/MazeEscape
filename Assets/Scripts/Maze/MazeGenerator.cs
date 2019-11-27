using System.Collections.Generic;

namespace Assets.Scripts.Maze {
    /*
     * Creates a random maze.
     */
    public class MazeGenerator {
        private MazeData MazeData;
        private List<TwoTuple<Cell>> CellPairs { get; set; }

        public MazeGenerator(MazeData mazeData) {
            MazeData = new MazeData {
                Width = mazeData.Width,
                Height = mazeData.Height,
                CellSideLength = mazeData.CellSideLength,
                CellWallThickness = mazeData.CellWallThickness,
            };
            CellPairs = new List<TwoTuple<Cell>>();
        }

        public MazeData CreateMaze() {
            if (MazeData.Width > 0 && MazeData.Height > 0) {
                SetupModel();
                MazeData.Maze = CreateMazeMatrix();
            }
            return MazeData;
        }

        private void SetupModel() {
            CreateCells();
            CreateCellPairs();
            CreateCellPartitions();
            RandomizeListOfCellPairs();
            CreateInteriorWallsAndDoors();
        }

        private Cell[,] CreateMazeMatrix() {
            Cell[,] Maze = new Cell[0, 0];
            if (MazeData.Width > 0 && MazeData.Height > 0) {
                MazeData.Maze = new Cell[MazeData.Height, MazeData.Width];
                InitializeMazeMatrix();
                Maze = CreateOutsideWallsAndDoors();
            }

            return Maze;
        }

        private void CreateCells() {
            MazeData.Cells = new List<Cell>();
            for (int i = 0; i < (MazeData.Width * MazeData.Height); i++) {
                MazeData.Cells.Add(new Cell(i, MazeData.CellSideLength));
            }
        }

        // Assumes that cells have already been created
        private void CreateCellPairs() {
            CellPairs = new List<TwoTuple<Cell>>();
            for (int i = 0; i < (MazeData.Width * MazeData.Height); i++) {
                if (!AtRightEdge(i)) {
                    CellPairs.Add(new TwoTuple<Cell>(MazeData.Cells[i], MazeData.Cells[i + 1]));
                }
                if (!AtBottomEdge(i)) {
                    CellPairs.Add(new TwoTuple<Cell>(MazeData.Cells[i], MazeData.Cells[i + MazeData.Width]));
                }
            }
        }

        private void CreateCellPartitions() {
            for (int i = 0; i < (MazeData.Width * MazeData.Height); i++) {
                Tree<Cell> tree = new Tree<Cell>(MazeData.Cells[i]);
                MazeData.Cells[i].TreeNodePointer = tree;
            }
        }

        private void RandomizeListOfCellPairs() {
            System.Random r = new System.Random();
            for (int i = 0; i < CellPairs.Count; i++) {
                int randomPosition = r.Next(CellPairs.Count);
                TwoTuple<Cell> firstPair = CellPairs[i];
                TwoTuple<Cell> secondPair = CellPairs[randomPosition];
                CellPairs[i] = secondPair;
                CellPairs[randomPosition] = firstPair;
            }
        }

        private void CreateInteriorWallsAndDoors() {
            while (CellPairs.Count > 0) {
                TwoTuple<Cell> cellPair = CellPairs[0];
                CellPairs.RemoveAt(0);
                if (CellsInSameTree(cellPair)) {
                    CreateDoor(cellPair);
                } else {
                    CreateWall(cellPair);
                }
            }
        }

        private Cell[,] CreateOutsideWallsAndDoors() {
            Cell[,] maze = MazeData.Maze;
            for (int row = 0; row < MazeData.Height; row++) {
                for (int col = 0; col < MazeData.Width; col++) {
                    Cell cell = maze[row, col];
                    AddOutsideWallsAndDoorsToCell(cell, row, col);
                }
            }
            return maze;
        }

        private void InitializeMazeMatrix() {
            for (int row = 0; row < MazeData.Height; row++) {
                for (int col = 0; col < MazeData.Width; col++) {
                    MazeData.Maze[row, col] = MazeData.Cells[row * MazeData.Width + col];
                }
            }
        }

        private void CreateDoor(TwoTuple<Cell> cellPair) {
            Cell firstCell = cellPair.X;
            Cell secondCell = cellPair.Y;
            Tree<Cell> treeOne = firstCell.TreeNodePointer;
            Tree<Cell> treeTwo = secondCell.TreeNodePointer;
            treeOne.MergeWith(treeTwo);
        }

        private void CreateWall(TwoTuple<Cell> cellPair) {
            Cell firstCell = cellPair.X;
            Cell secondCell = cellPair.Y;

            if (CellsOnTopOfEachOther(cellPair)) {
                firstCell.HasBottomWall = true;
                secondCell.HasTopWall = true;
            } else {
                firstCell.HasRightWall = true;
                secondCell.HasLeftWall = true;
            }
        }

        private void AddOutsideWallsAndDoorsToCell(Cell cell, int row, int col) {
            if (PartOfLeftEdge(row, col)) {
                cell.HasLeftWall = true;
            }

            if (PartOfTopEdge(row)) {
                cell.HasTopWall = true;
            }

            if (PartOfRightEdge(col)) {
                cell.HasRightWall = true;
            }

            if (PartOfBottomEdge(row, col)) {
                cell.HasBottomWall = true;
            }
        }

        private bool CellsOnTopOfEachOther(TwoTuple<Cell> cellPair) {
            Cell firstCell = cellPair.X;
            Cell secondCell = cellPair.Y;
            return firstCell.Id != (secondCell.Id - 1);
        }

        private bool CellsInSameTree(TwoTuple<Cell> cellPair) {
            Cell firstCell = cellPair.X;
            Cell secondCell = cellPair.Y;
            Tree<Cell> TreeOne = firstCell.TreeNodePointer;
            Tree<Cell> TreeTwo = secondCell.TreeNodePointer;
            return (!TreeOne.IsInSameTreeAs(TreeTwo));
        }

        private bool AtRightEdge(int cellId) {
            return (cellId + 1) % MazeData.Width == 0;
        }

        private bool AtBottomEdge(int cellId) {
            return ((MazeData.Height - 1) * MazeData.Width) <= cellId && cellId < (MazeData.Height * MazeData.Width);
        }

        private bool PartOfLeftEdge(int row, int col) {
            return col == 0 && row != 0;
        }

        private bool PartOfRightEdge(int col) {
            return col == (MazeData.Width - 1);
        }

        private bool PartOfTopEdge(int row) {
            return row == 0;
        }

        private bool PartOfBottomEdge(int row, int col) {
            return (row == (MazeData.Height - 1)) && (col != (MazeData.Width - 1));
        }
    }
}
