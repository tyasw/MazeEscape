using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class MazeModel {
    public int Width { get; set; }
    public int Height { get; set; }
    public float CellSize { get; set; }
    public float CellWallThickness { get; set; }
    public List<Cell> Cells { get; set; }
    public Cell[,] Maze { get; set; }
    public List<TwoTuple<Cell>> Walls { get; set; }

    private List<TwoTuple<Cell>> CellPairs { get; set; }

    public MazeModel() {
        Width = 0;
        Height = 0;
        CellSize = 0.0f;
        CellWallThickness = 0.0f;
        Cells = new List<Cell>();
        Maze = new Cell[0,0];
        Walls = new List<TwoTuple<Cell>>();
        CellPairs = new List<TwoTuple<Cell>>();
    }

    public void CreateMaze() {
        if (Width > 0 && Height > 0) {
            SetupModel();
            Maze = CreateMazeMatrix();
        }
    }

    private void SetupModel() {
        CreateCells();
        CreateCellPairs();
        CreateCellPartitions();
        RandomizeListOfCellPairs();
        CreateInteriorWallsAndDoors();
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

    private Cell[,] CreateMazeMatrix() {
        if (Width > 0 && Height > 0) {
            Maze = new Cell[Height,Width];
            InitializeMazeMatrix();
            Maze = CreateOutsideWallsAndDoors(Maze);
        } else {
            Maze = new Cell[0,0];
        }

        return Maze;      
    }

    private void CreateCells() {
        for (int i = 0; i < (Width * Height); i++) {
            Cells.Add(new Cell(i,CellSize));
        }
    }

    // Assumes that cells have already been created
    private void CreateCellPairs() {
        for (int i = 0; i < (Width * Height); i++) {
            if ((i + 1) % Width != 0) {   // Not at far right edge
                CellPairs.Add(new TwoTuple<Cell>(Cells[i],Cells[i + 1]));
            }
            if (!(((Height - 1) * Width) <= i && i < (Height * Width))) {   // Not at bottom edge
                CellPairs.Add(new TwoTuple<Cell>(Cells[i],Cells[i + Width]));
            }
        }
    }

    private void CreateCellPartitions() {
        for (int i = 0; i < (Width * Height); i++) {
            Tree<Cell> tree = new Tree<Cell>(Cells[i]);
            Cells[i].TreeNodePointer = tree;
        }
    }

    // For each cell pair, swap with a pair at a random location
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

    private bool CellsInSameTree(TwoTuple<Cell> cellPair) {
        Cell firstCell = cellPair.X;
        Cell secondCell = cellPair.Y;
        Tree<Cell> TreeOne = firstCell.TreeNodePointer;
        Tree<Cell> TreeTwo = secondCell.TreeNodePointer;
        return (!TreeOne.IsInSameTreeAs(TreeTwo));
    }

    private void CreateWall(TwoTuple<Cell> cellPair) {
        Walls.Add(cellPair);

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

    private bool CellsOnTopOfEachOther(TwoTuple<Cell> cellPair) {
        Cell firstCell = cellPair.X;
        Cell secondCell = cellPair.Y;
        return firstCell.Id != (secondCell.Id - 1);
    }

    private void CreateDoor(TwoTuple<Cell> cellPair) {
        Cell firstCell = cellPair.X;
        Cell secondCell = cellPair.Y;
        Tree<Cell> treeOne = firstCell.TreeNodePointer;
        Tree<Cell> treeTwo = secondCell.TreeNodePointer;
        treeOne.MergeWith(treeTwo);
    }

    private void InitializeMazeMatrix() {
        for (int row = 0; row < Height; row++) {
            for (int col = 0; col < Width; col++) {
                Maze[row,col] = Cells[row * Width + col];
            }
        }
    }

    private Cell[,] CreateOutsideWallsAndDoors(Cell[,] mazeWithoutOutsideWalls) {
        Cell[,] maze = mazeWithoutOutsideWalls;
        for (int row = 0; row < Height; row++) {
            for (int col = 0; col < Width; col++) {
                if (col == 0 && row != 0) {
                    maze[row, col].LeftWall = true;
                }

                if (row == 0) {
                    maze[row, col].TopWall = true;
                }

                if (col == (Width - 1)) {
                    maze[row, col].RightWall = true;
                }

                if ((row == (Height - 1)) && (col != (Width - 1))) {
                    maze[row, col].BottomWall = true;
                }
            }
        }
        return maze;
    }
}
