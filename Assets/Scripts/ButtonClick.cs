using UnityEngine.UI;

public interface ButtonClick {
    Button Button { get; set; }
    EventHandler EventHandler { get; set; }

    void HandleClick();
}
