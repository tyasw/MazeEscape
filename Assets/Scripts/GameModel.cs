public class GameModel {
    public MazeModel MazeModel { get; set; }

    public GameModel() {
        MazeModel = new MazeModel();
    }

    public void BeginGameWithOptionsApplied() {
        GetGameOptions();
        MazeController mazeController = new MazeController(MazeModel);
        mazeController.CreateMaze();
    }

    // TODO: get the options from an options file
    private void GetGameOptions() {
        MazeModel.CellSize = 4.0f;
        MazeModel.Width = 5;
        MazeModel.Height = 4;
        MazeModel.CellWallThickness = 0.1f;
    }
}
