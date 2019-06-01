using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour {
    public Text GameTimeText;
    public float timeStartedMaze;
    public float elapsedTime;

    private void Awake() {
        GameTimeText = GetComponent<Text>();
    }

    private void Start() {
        timeStartedMaze = Time.time;
    }

    private void Update() {
        elapsedTime = Time.time - timeStartedMaze;
        GameTimeText.text = "Time: " + elapsedTime.ToString().Substring(0, 4);
    }
}
