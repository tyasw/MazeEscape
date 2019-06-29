using UnityEngine;
using UnityEngine.SceneManagement;
using Assets.Scripts.Events;

/*
 * The top-level class in Maze Escape. It should be attached to a GameObject
 * in Unity. It creates the game model and view, and subscribes to a few events.
 * When you need to control the order in which different observers respond to
 * a change, do it here.
 */
public class UnityController : MonoBehaviour, GameController {
    public GameModel GameModel;
    public UnityView GameView;
    public CustomEventSystem EventSystem;

    void Awake() {
        EventSystem = GameObject.FindObjectOfType<CustomEventSystem>();
        GameModel = GetComponent<GameModel>();
        GameView = GetComponent<UnityView>();
        InitializeEvents();
    }

    private void Start() {
        StartNewGame();
    }

    private void InitializeEvents() {
        EventSystem.RegisterListener(typeof(StopGameEvent), StopGame);
        EventSystem.RegisterListener(typeof(RestartGameEvent), RestartGame);
        EventSystem.RegisterListener(typeof(WonGameEvent), WinGame);
    }

    public void StartNewGame() {
        GameModel.BeginGameWithOptionsApplied();
        GameView.DrawWorld();
    }

    public void RestartGame() {
        SceneManager.LoadScene("Game");
    }

    public void StopGame() {
        Application.Quit();
    }

    public void WinGame() {
        GameModel.GameData.GameWon = true;
    }
}
