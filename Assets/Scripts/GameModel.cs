using Assets.Scripts.Maze;

public class GameModel {
    public ClassFactory ClassFactory { get; set; }
    public GameData GameData { get; set; }
    public MazeModel MazeModel { get; set; }

    public GameModel() {
        ClassFactory = ClassFactory.GetInstance();
        GameData = ClassFactory.GetGameData();
        MazeModel = ClassFactory.GetMazeModel();
    }

    public void BeginGameWithOptionsApplied() {
        GetGameOptions();
        MazeController mazeController = new MazeController(MazeModel);
        mazeController.CreateMaze();
    }

    // TODO: get the options from an options file
    private void GetGameOptions() {
        MazeData mazeData = ClassFactory.GetMazeData();
        mazeData.CellSize = 4.0f;
        mazeData.Width = 8;
        mazeData.Height = 8;
        mazeData.CellWallThickness = 0.1f;
    }
}
