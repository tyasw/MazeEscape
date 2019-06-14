using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour {
    public Text GameTimeText;
    public float timeStartedMaze;
    public float elapsedTime;

    public bool timerShouldRun;

    private void Awake() {
        GameTimeText = GetComponent<Text>();
    }

    private void Start() {
        timeStartedMaze = Time.time;
        GameTimeText.text = " ";
    }

    private void Update() {
        if (timerShouldRun) {
            elapsedTime = Time.time - timeStartedMaze;
            GameTimeText.text = "Time: " + elapsedTime.ToString().Substring(0, 4); 
        }
    }
}
