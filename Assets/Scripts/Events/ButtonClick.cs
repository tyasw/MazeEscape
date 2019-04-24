using UnityEngine.UI;

namespace Assets.Scripts.Events {
    public interface ButtonClick {
        Button Button { get; set; }
        EventHandler EventHandler { get; set; }

        void HandleClick();
    }
}
