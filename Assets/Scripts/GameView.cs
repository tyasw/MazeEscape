public interface GameView {
    GameModel GameModel { get; set; }
    int MazeWidth { get; set; }
    int MazeHeight { get; set; }

    void DrawWorld();
    void DrawMaze();
}