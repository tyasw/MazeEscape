using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell {
    public int Id { get; set; }
    public float Size { get; set; }           // length of one side of the cell
    public Tree<Cell> TreeNodePointer { get; set; }
    public bool TopWall { get; set; }
    public bool BottomWall { get; set; }
    public bool LeftWall { get; set; }
    public bool RightWall { get; set; }

    public Cell(int id,float size) {
        Id = id;
        Size = size;
        TreeNodePointer = null;
        TopWall = false;
        BottomWall = false;
        LeftWall = false;
        RightWall = false;
    }
}
