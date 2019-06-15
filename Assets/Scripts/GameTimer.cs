using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour {
    public Text GameTimeText;
    public float elapsedTime;

    private void Awake() {
        GameTimeText = GetComponent<Text>();
    }

    private void Start() {
        elapsedTime = 0.0f;
        GameTimeText.text = " ";
    }

    private void Update() {
        elapsedTime += Time.deltaTime;
        GameTimeText.text = "Time: " + elapsedTime.ToString("f2"); 
    }
}
