using Assets.Scripts.Maze;

public class ClassFactory {
    private static ClassFactory Instance { get; set; }
    private GameModel GameModelInstance { get; set; }
    private GameData GameDataInstance { get; set; }
    private MazeModel MazeModelInstance { get; set; }
    private MazeData MazeDataInstance { get; set; }

    private ClassFactory() {

    }

    public static ClassFactory GetInstance() {
        if (Instance == null) {
            Instance = new ClassFactory();
        }
        return Instance;
    }

    public GameModel GetGameModel() {
        if (GameModelInstance == null) {
            GameData gameData = GetGameData();
            MazeModel mazeModel = GetMazeModel();
            GameModelInstance = new GameModel(gameData, mazeModel);
        }
        return GameModelInstance;
    }

    public GameData GetGameData() {
        if (GameDataInstance == null) {
            GameDataInstance = new GameData();
        }
        return GameDataInstance;
    }

    public MazeModel GetMazeModel() {
        if (MazeModelInstance == null) {
            MazeData mazeData = GetMazeData();
            MazeModelInstance = new MazeModel(mazeData);
        }
        return MazeModelInstance;
    }

    public MazeData GetMazeData() {
        if (MazeDataInstance == null) {
            MazeDataInstance = new MazeData();
        }
        return MazeDataInstance;
    }
}
