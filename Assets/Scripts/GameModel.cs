public class GameModel {
    public GameData GameData { get; set; }
    public MazeModel MazeModel { get; set; }

    private static GameModel GameModelInstance = null;

    private GameModel() {
        GameData = GameData.GetInstance();
        MazeModel = MazeModel.GetInstance();
    }

    public static GameModel GetInstance() {
        if (GameModelInstance == null) {
            GameModelInstance = new GameModel();
        }
        return GameModelInstance;
    }

    public void BeginGameWithOptionsApplied() {
        GetGameOptions();
        MazeController mazeController = new MazeController(MazeModel);
        mazeController.CreateMaze();
    }

    // TODO: get the options from an options file
    private void GetGameOptions() {
        MazeData mazeData = MazeData.GetInstance();
        mazeData.CellSize = 4.0f;
        mazeData.Width = 8;
        mazeData.Height = 8;
        mazeData.CellWallThickness = 0.1f;
    }
}
