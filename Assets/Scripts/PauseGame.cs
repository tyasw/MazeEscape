using UnityEngine;

public class PauseGame : MonoBehaviour {
    private float SavedTimescale;

    private void OnEnable() {
        SavedTimescale = Time.timeScale;
        Time.timeScale = 0.0f;
    }

    private void OnDisable() {
        Time.timeScale = SavedTimescale;
    }
}
