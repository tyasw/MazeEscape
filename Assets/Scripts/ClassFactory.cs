using Assets.Scripts.Events;
using Assets.Scripts.Maze;

public class ClassFactory {
    private static ClassFactory Instance { get; set; }
    private GameModel GameModelInstance { get; set; }
    private GameData GameDataInstance { get; set; }
    private MazeModel MazeModelInstance { get; set; }
    private MazeData MazeDataInstance { get; set; }

    private CommandParser CommandParserInstance { get; set; }
    private PauseGameEvent PauseGameEventInstance { get; set; }
    private ResumeGameEvent ResumeGameEventInstance { get; set; }
    private ShowGameOptionsEvent ShowGameOptionsEventInstance { get; set; }
    private StartGameEvent StartGameEventInstance { get; set; }
    private StopGameEvent StopGameEventInstance { get; set; }
    private MazeStartedEvent MazeStartedEventInstance { get; set; }
    private WonGameEvent WonGameEventInstance { get; set; }
    private RestartGameEvent RestartGameEventInstance { get; set; }

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

    public CommandParser GetCommandParser() {
        if (CommandParserInstance == null) {
            CommandParserInstance = new CommandParser();
        }
        return CommandParserInstance;
    }

    public PauseGameEvent GetPauseGameEvent() {
        if (PauseGameEventInstance == null) {
            PauseGameEventInstance = new PauseGameEvent();
        }
        return PauseGameEventInstance;
    }

    public ResumeGameEvent GetResumeGameEvent() {
        if (ResumeGameEventInstance == null) {
            ResumeGameEventInstance = new ResumeGameEvent();
        }
        return ResumeGameEventInstance;
    }

    public ShowGameOptionsEvent GetShowGameOptionsEvent() {
        if (ShowGameOptionsEventInstance == null) {
            ShowGameOptionsEventInstance = new ShowGameOptionsEvent();
        }
        return ShowGameOptionsEventInstance;
    }

    public StartGameEvent GetStartGameEvent() {
        if (StartGameEventInstance == null) {
            StartGameEventInstance = new StartGameEvent();
        }
        return StartGameEventInstance;
    }

    public StopGameEvent GetStopGameEvent() {
        if (StopGameEventInstance == null) {
            StopGameEventInstance = new StopGameEvent();
        }
        return StopGameEventInstance;
    }

    public MazeStartedEvent GetMazeStartedEvent() {
        if (MazeStartedEventInstance == null) {
            MazeStartedEventInstance = new MazeStartedEvent();
        }
        return MazeStartedEventInstance;
    }

    public WonGameEvent GetWonGameEvent() {
        if (WonGameEventInstance == null) {
            WonGameEventInstance = new WonGameEvent();
        }
        return WonGameEventInstance;
    }

    public RestartGameEvent GetRestartGameEvent() {
        if (RestartGameEventInstance == null) {
            RestartGameEventInstance = new RestartGameEvent();
        }
        return RestartGameEventInstance;
    }
}
