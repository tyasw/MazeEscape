using UnityEngine;
using Assets.Scripts.Commands;

/*
 * Placed at the exit to the maze. The "instantiation" of this class is
 * controlled by the CheckpointCreator.
 */
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