using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityView : GameView {
    public GameModel GameModel { get; set; }
    public int MazeWidth { get; set; }
    public int MazeHeight { get; set; }

    private Cell[,] Maze { get; set; }  // row x col

    public UnityView(GameModel gameModel) {
        GameModel = gameModel;
        Maze = new Cell[0, 0];
        MazeWidth = GameModel.GetMazeWidth();
        MazeHeight = GameModel.GetMazeHeight();
    }

    public void DrawWorld() {
        //...
        DrawMaze();
    }

    public void DrawMaze() {
        MazeWidth = GameModel.GetMazeWidth();
        MazeHeight = GameModel.GetMazeHeight();
        Maze = GameModel.MazeModel.Maze;
        float wallWidth = GameModel.MazeModel.CellSize;
        float wallThickness = GameModel.MazeModel.CellWallThickness;
        MazeDrawer mazeDrawer = new MazeDrawer(MazeWidth, MazeHeight, Maze, wallWidth, wallThickness);
        mazeDrawer.DrawMaze();
    }
}