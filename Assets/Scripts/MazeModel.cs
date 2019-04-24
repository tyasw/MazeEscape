using System.Collections.Generic;

public class MazeModel {
    private static MazeModel MazeModelInstance = null;
    private MazeData MazeData;
    private List<TwoTuple<Cell>> CellPairs { get; set; }

    private MazeModel() {
        MazeData = MazeData.GetInstance();
        CellPairs = new List<TwoTuple<Cell>>();
    }

    public static MazeModel GetInstance() {
        if (MazeModelInstance == null) {
            MazeModelInstance = new MazeModel();
        }
        return MazeModelInstance;
    }

    public void CreateMaze() {
        if (MazeData.Width > 0 && MazeData.Height > 0) {
            SetupModel();
            MazeData.Maze = CreateMazeMatrix();
        }
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
        for (int i = 0; i < (MazeData.Width * MazeData.Height); i++) {
            MazeData.Cells.Add(new Cell(i, MazeData.CellSize));
        }
    }

    // Assumes that cells have already been created
    private void CreateCellPairs() {
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
            firstCell.BottomWall = true;
            secondCell.TopWall = true;
        } else {
            firstCell.RightWall = true;
            secondCell.LeftWall = true;
        }
    }

    private void AddOutsideWallsAndDoorsToCell(Cell cell, int row, int col) {
        if (PartOfLeftEdge(row, col)) {
            cell.LeftWall = true;
        }

        if (PartOfTopEdge(row)) {
            cell.TopWall = true;
        }

        if (PartOfRightEdge(col)) {
            cell.RightWall = true;
        }

        if (PartOfBottomEdge(row, col)) {
            cell.BottomWall = true;
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
