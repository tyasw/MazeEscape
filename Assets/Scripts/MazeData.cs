﻿using System.Collections.Generic;

public class MazeData {
    public int Width { get; set; }
    public int Height { get; set; }
    public float CellSize { get; set; }
    public float CellWallThickness { get; set; }
    public List<Cell> Cells { get; set; }
    public Cell[,] Maze { get; set; }   // row x col

    private static MazeData MazeDataInstance = null;

    private MazeData() {
        Width = 0;
        Height = 0;
        CellSize = 0.0f;
        CellWallThickness = 0.0f;
        Cells = new List<Cell>();
        Maze = new Cell[0, 0];
    }

    public static MazeData GetInstance() {
        if (MazeDataInstance == null) {
            MazeDataInstance = new MazeData();
        }
        return MazeDataInstance;
    }
}