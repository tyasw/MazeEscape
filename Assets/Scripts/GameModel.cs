public class GameModel {
    private static GameModel GameModelInstance = null;
    public MazeModel MazeModel { get; set; }

    private GameModel() {
        MazeModel = new MazeModel();
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
        GameModelInstance.MazeModel.MazeData.CellSize = 4.0f;
        GameModelInstance.MazeModel.MazeData.Width = 5;
        GameModelInstance.MazeModel.MazeData.Height = 4;
        GameModelInstance.MazeModel.MazeData.CellWallThickness = 0.1f;
    }
}
