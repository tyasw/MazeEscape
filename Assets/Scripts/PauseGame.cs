using UnityEngine;

/*
 * Scripts that need to check whether the game is paused should get a
 * reference to this script. It will be enabled or disabled by the
 * HUDAnimator, which is attached to the HUD GameObject.
 */
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
