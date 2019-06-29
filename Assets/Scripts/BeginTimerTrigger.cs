using UnityEngine;
using Assets.Scripts.Commands;

/*
 * Placed at the beginning of the maze. The "instantiation" of this class is
 * controlled by the CheckpointCreator.
 */
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