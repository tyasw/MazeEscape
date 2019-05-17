using UnityEngine;
using Assets.Scripts.Commands;

public class WinTrigger : MonoBehaviour {
    public FinishGameCommand FinishGameCommand;

    private void Awake() {
        FinishGameCommand = GetComponent<FinishGameCommand>();
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            FinishGameCommand.Run();
        }
    }
}