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
    private List<TwoTuple<Cell>> Doors { get; set; }

    public MazeModel() {
        Width = 20;
        Height = 20;
        CellSize = 0.0f;
        CellWallThickness = 0.1f;
        Cells = new List<Cell>();
        Maze = new Cell[0,0];
        Walls = new List<TwoTuple<Cell>>();
        CellPairs = new List<TwoTuple<Cell>>();
        Doors = new List<TwoTuple<Cell>>();
    }

    public void CreateMaze() {
        if (Width > 0 && Height > 0) {
            SetupModel();

            while (CellPairs.Count > 0) {
                TwoTuple<Cell> cellPair = CellPairs[0];
                CellPairs.RemoveAt(0);

                Cell firstCell = cellPair.X;
                Cell secondCell = cellPair.Y;

                Tree<Cell> TreeOne = firstCell.TreeNodePointer;
                Tree<Cell> TreeTwo = secondCell.TreeNodePointer;

                if (!TreeOne.IsInSameTreeAs(TreeTwo)) {
                    Doors.Add(cellPair);
                    TreeOne.MergeWith(TreeTwo);
                } else {
                    Walls.Add(cellPair);
                }
            }

            Maze = CreateMazeMatrix();
        }
    }

    private Cell[,] CreateMazeMatrix() {
        if (Width > 0 && Height > 0) {
            Maze = new Cell[Height,Width];

            for (int row = 0; row < Height; row++) {
                for (int col = 0; col < Width; col++) {
                    Maze[row,col] = Cells[row * Width + col];
                }
            }

            CreateTopMazeEdge();
            CreateMiddleMazeWalls(Walls);
            CreateLeftAndRightMazeEdges();
            CreateBottomMazeEdge();
        } else {
            Maze = new Cell[0,0];
        }

        return Maze;      
    }

    private void CreateTopMazeEdge() {
        for (int col = 0; col < Width; col++) {
            Maze[0,col].TopWall = true;
        }
    }

    private void CreateMiddleMazeWalls(List<TwoTuple<Cell>> mazeWalls) {
        foreach (TwoTuple<Cell> tuple in mazeWalls) {
            int cellOneId = tuple.X.Id;
            int cellTwoId = tuple.Y.Id;
            int mazeRow = cellOneId / Width + 1;

            if (Width == 1 || ((cellTwoId - cellOneId) > 1)) {   // cellOne on top of cellTwo
                tuple.X.BottomWall = true;
                tuple.Y.TopWall = true;
            } else {   // cellTwo to the right of cellOne
                tuple.X.RightWall = true;
                tuple.Y.LeftWall = true;
            }
        }
    }

    private void CreateBottomMazeEdge() {
        for (int col = 0; col < Width; col++) {
            if (col != (Width - 1)) {
                Maze[Height - 1,col].BottomWall = true;
            }
        }
    }

    private void CreateLeftAndRightMazeEdges() {
        for (int row = 0; row < Height; row++) {
            if (row != 0) {
                Maze[row,0].LeftWall = true;
            }
            Maze[row,Width - 1].RightWall = true;
        }
    }


    private void SetupModel() {
        CreateCells();
        CreateCellPairs();
        CreateCellPartitions();
        RandomizeListOfCellPairs();
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
}
