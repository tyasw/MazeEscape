using Assets.Scripts.Commands;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Events {
    public class ResumeGameButtonClick : MonoBehaviour, ButtonClick {
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
            Debug.Log("Resume Game!");
            GameObject gameControllerObject = GameObject.FindGameObjectWithTag("GameController");
            GameController gameController = gameControllerObject.GetComponent<GameController>();
            Command command = new ResumeGameCommand(gameController);
            EventHandler.Notify(command);
        }
    }
}
