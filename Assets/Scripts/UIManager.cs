using UnityEngine;
using Assets.Scripts.Events;

/*
 * Controls the UI in the game. The UIManager is notified when certain
 * events occur, and triggers something on the animator attached to the HUD.
 * This class must be attached to a GameObject in the main scene in Unity.
 */
public class UIManager : MonoBehaviour {
    public Canvas HUDOverlay;
    public Animator HUDAnimator;
    public GameTimer GameTimer;

    public CustomEventSystem EventSystem;

    void Awake() {
        EventSystem = GameObject.FindObjectOfType<CustomEventSystem>();
        InitializeEvents();
        HUDOverlay.gameObject.SetActive(true);
        GameTimer.gameObject.SetActive(false);
        HUDAnimator = GameObject.Find("HUD").GetComponent<Animator>();
    }

    private void InitializeEvents() {
        EventSystem.RegisterListener(typeof(MazeStartedEvent), StartTimer);
        EventSystem.RegisterListener(typeof(StartGameEvent), StartNewGame);
        EventSystem.RegisterListener(typeof(PauseGameEvent), PauseGame);
        EventSystem.RegisterListener(typeof(ResumeGameEvent), ResumeGame);
        EventSystem.RegisterListener(typeof(WonGameEvent), GameWon);
    }

    private void StartTimer() {
        HUDAnimator.SetBool("InsideMaze", true);
    }

    private void GameWon() {
        HUDAnimator.SetTrigger("WinGame");
    }

    private void StartNewGame() {
        HUDAnimator.SetTrigger("MainMenuDisappear");
    }

    private void PauseGame() {
        HUDAnimator.SetBool("Paused", true);
    }

    private void ResumeGame() {
        HUDAnimator.SetBool("Paused", false);
    }
}
