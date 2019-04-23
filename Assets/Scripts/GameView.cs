public interface GameView {
    GameModel GameModel { get; set; }

    void DrawWorld();
    void DrawMaze();
}