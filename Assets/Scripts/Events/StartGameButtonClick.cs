using Assets.Scripts.Commands;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Events {
    public class StartGameButtonClick : MonoBehaviour, ButtonClick {
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
            Debug.Log("Start game!");
            GameObject gameControllerObject = GameObject.FindGameObjectWithTag("GameController");
            GameController gameController = gameControllerObject.GetComponent<GameController>();
            Command command = new BeginGameCommand(gameController);
            EventHandler.Notify(command);
        }
    }
}
