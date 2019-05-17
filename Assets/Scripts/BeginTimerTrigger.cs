using UnityEngine;
using Assets.Scripts.Commands;

public class BeginTimerTrigger : MonoBehaviour {
    public BeginTimerCommand BeginTimerCommand;

    private void Awake() {
        BeginTimerCommand = GetComponent<BeginTimerCommand>();
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            BeginTimerCommand.Run();
        }
    }
}