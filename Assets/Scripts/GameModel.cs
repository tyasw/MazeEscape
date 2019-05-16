using System.Collections.Generic;
using Assets.Scripts.Events;
using Assets.Scripts.Maze;

public class GameModel : Observer {
    public ClassFactory ClassFactory { get; set; }
    public GameData GameData { get; set; }
    public MazeModel MazeModel { get; set; }
    private List<Subject> Events;

    public GameModel(GameData gameData, MazeModel mazeModel) {
        ClassFactory = ClassFactory.GetInstance();
        GameData = gameData;
        MazeModel = mazeModel;
        Events = InitializeEvents();
        AttachToEvents();
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
        mazeData.Width = 8;
        mazeData.Height = 8;
        mazeData.CellWallThickness = 0.1f;
    }

    private List<Subject> InitializeEvents() {
        List<Subject> watchingEvents = new List<Subject>();
        WonGameEvent wonGameEvent = ClassFactory.GetWonGameEvent();
        watchingEvents.Add(wonGameEvent);
        return watchingEvents;
    }

    private void AttachToEvents() {
        foreach (Subject subject in Events) {
            subject.Attach(this);
        }
    }

    public void UpdateObserver(Subject subject) {
        switch (subject.ToString()) {
            case "GameWonEvent":
                GameData.GameWon = true;
                GameData.Notify();
                break;
            default:
                break;
        }
    }
}
