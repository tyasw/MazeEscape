public interface GameView {
    GameModel GameModel { get; set; }
    MazeTransformer MazeTransformer { get; set; }
    int MazeWidth { get; set; }
    int MazeHeight { get; set; }

    void DrawMaze();
}