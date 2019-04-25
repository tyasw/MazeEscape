using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Events {
    public class ButtonClick : MonoBehaviour {
        [SerializeField]
        private Button _Button;
        public Button Button {
            get { return _Button; }
            set { _Button = value; }
        }
        public GameEvent Event;
        public GameController GameController;

        private void Start() {
            GameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
            Button.onClick.AddListener(OnClick);
            Event = GetComponent<GameEvent>();
        }

        void OnClick() {
            Event.Trigger(GameController);
        }
    }
}
