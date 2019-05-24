using UnityEngine;

class PauseGame : MonoBehaviour {
    public bool Paused;

    private float SavedTimescale;

    private void Start() {
        Paused = false;
        SavedTimescale = Time.timeScale;
    }

    private void Update() {
        if (Paused) {
            SavedTimescale = Time.timeScale;
            Time.timeScale = 0.0f;
        } else {
            Time.timeScale = SavedTimescale;
        }
    }
}
