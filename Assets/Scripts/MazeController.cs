using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeController {
    private MazeModel Model { get; set; }

    public MazeController(MazeModel model) {
        Model = model;
    }

    public void CreateMaze() {
        Model.CreateMaze();
    }
}
