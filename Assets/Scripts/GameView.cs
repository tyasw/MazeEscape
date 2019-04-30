using Assets.Scripts.Maze;

public interface GameView {
    MazeData MazeData { get; set; }
    GameModel GameModel { get; set; }

    void DrawWorld();
    void DrawMaze();
}