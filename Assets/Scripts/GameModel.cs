using Assets.Scripts.Maze;

public class GameModel {
    public ClassFactory ClassFactory { get; set; }
    public GameData GameData { get; set; }
    public MazeModel MazeModel { get; set; }

    public GameModel(GameData gameData, MazeModel mazeModel) {
        ClassFactory = ClassFactory.GetInstance();
        GameData = gameData;
        MazeModel = mazeModel;
    }

    public void BeginGameWithOptionsApplied() {
        GetGameOptions();
        MazeController mazeController = new MazeController(MazeModel);
        mazeController.CreateMaze();
    }

    // TODO: get the options from an options file
    private void GetGameOptions() {
        ClassFactory classFactory = ClassFactory.GetInstance();
        MazeData mazeData = classFactory.GetMazeData();
        mazeData.CellSize = 10.0f;
        mazeData.Width = 2;
        mazeData.Height = 2;
        mazeData.CellWallThickness = 0.1f;
    }
}
