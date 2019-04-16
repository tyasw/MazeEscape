using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeTransformer {
    private MazeModel MazeModel { get; set; }
    private Cell[,] Maze { get; set; }
    private int MazeWidth { get; set; }
    private int MazeHeight { get; set; }

    public MazeTransformer(MazeModel mazeModel) {
        MazeModel = mazeModel;
        MazeWidth = 0;
        MazeHeight = 0;
    }

    public Cell[,] CreateMazeMatrix() {
        MazeWidth = MazeModel.Width;
        MazeHeight = MazeModel.Height;
        List<TwoTuple<Cell>> mazeWalls = MazeModel.Walls;
        List<Cell> cells = MazeModel.Cells;

        if (MazeWidth > 0 && MazeHeight > 0) {
            Maze = new Cell[MazeHeight,MazeWidth];

            for (int row = 0; row < MazeHeight; row++) {
                for (int col = 0; col < MazeWidth; col++) {
                    Maze[row,col] = cells[row * MazeWidth + col];
                }
            }

            CreateTopMazeEdge();
            CreateMiddleMazeWalls(mazeWalls);
            CreateLeftAndRightMazeEdges();
            CreateBottomMazeEdge();
        } else {
            Maze = new Cell[0,0];
        }

        return Maze;
    }

    private void CreateTopMazeEdge() {
        for (int col = 0; col < MazeWidth; col++) {
            Maze[0,col].TopWall = true;
        }
    }

    private void CreateMiddleMazeWalls(List<TwoTuple<Cell>> mazeWalls) {
        foreach (TwoTuple<Cell> tuple in mazeWalls) {
            int cellOneId = tuple.X.Id;
            int cellTwoId = tuple.Y.Id;
            int mazeRow = cellOneId / MazeWidth + 1;

            if (MazeWidth == 1 || ((cellTwoId - cellOneId) > 1)) {   // cellOne on top of cellTwo
                tuple.X.BottomWall = true;
                tuple.Y.TopWall = true;
            } else {   // cellTwo to the right of cellOne
                tuple.X.RightWall = true;
                tuple.Y.LeftWall = true;
            }
        }
    }

    private void CreateBottomMazeEdge() {
        for (int col = 0; col < MazeWidth; col++) {
            if (col != (MazeWidth - 1)) {
                Maze[MazeHeight - 1,col].BottomWall = true;
            }
        }
    }

    private void CreateLeftAndRightMazeEdges() {
        for (int row = 0; row < MazeHeight; row++) {
            if (row != 0) {
                Maze[row,0].LeftWall = true;
            }
            Maze[row,MazeWidth - 1].RightWall = true;
        }
    }
}
