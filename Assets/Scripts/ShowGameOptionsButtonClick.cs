using Assets.Scripts.Commands;
using UnityEngine;
using UnityEngine.UI;

class ShowGameOptionsButtonClick : MonoBehaviour, ButtonClick {
    [SerializeField]
    private Button _Button;
    public Button Button {
        get { return _Button; }
        set { _Button = value; }
    }
    public EventHandler EventHandler { get; set; }

    private void Start() {
        EventHandler = EventHandler.GetInstance();
        _Button.onClick.AddListener(HandleClick);
    }

    public void HandleClick() {
        Debug.Log("You have clicked the show new game options button!");
        GameObject gameControllerObject = GameObject.FindGameObjectWithTag("GameController");
        GameController gameController = gameControllerObject.GetComponent<GameController>();
        Command command = new ShowNewGameOptionsCommand(gameController);
        EventHandler.Notify(command);
    }
}
