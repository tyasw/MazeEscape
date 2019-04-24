using UnityEngine;

public class UnityController : MonoBehaviour, GameController {
    public GameModel GameModel;
    public GameView GameView;
    public EventHandler EventHandler;
    public GameOptions GameOptions;

    void Start() {
        GameModel = GameModel.GetInstance();
        GameView = GetComponent<UnityView>();
        EventHandler = EventHandler.GetInstance();
        GameOptions = GetComponent<UnityOptions>();
    }

    public void StartNewGame() {
        GameModel.BeginGameWithOptionsApplied();
        GameView.DrawWorld();
    }

    public void PauseGame() {
        GameOptions.PauseGame();
    }

    public void ResumeGame() {
        GameOptions.ResumeGame();
    }

    public void StopGame() {
        GameOptions.StopGame();
    }

    public void ShowMenu() {
        GameOptions.ShowMainMenu();
    }

    public void ShowGameOptions() {
        GameOptions.ShowGameOptions();
    }
}
