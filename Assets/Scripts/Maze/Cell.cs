using Assets.Scripts.Maze;

/*
 * A single cell in a maze.
 */
public class Cell {
    public int Id { get; set; }
    public float SideLength { get; set; }           // length of one side of the cell
    public Tree<Cell> TreeNodePointer { get; set; }
    public bool HasTopWall { get; set; }
    public bool HasBottomWall { get; set; }
    public bool HasLeftWall { get; set; }
    public bool HasRightWall { get; set; }

    public Cell(int id,float sideLength) {
        Id = id;
        SideLength = sideLength;
        TreeNodePointer = null;
        HasTopWall = false;
        HasBottomWall = false;
        HasLeftWall = false;
        HasRightWall = false;
    }
}
