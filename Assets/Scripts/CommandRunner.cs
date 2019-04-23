using UnityEngine;

public class CommandRunner : MonoBehaviour {
    private CommandParser CommandParser { get; set; }

    private void Start() {
        CommandParser = GetComponent<CommandParser>();
    }

    private void Update() {
        RunNextCommand();
    }

    private void RunNextCommand() {
        string commandName = CommandParser.RunNextCommand();
        if (commandName != "") {
            Debug.Log(commandName + " was just run");
        }
    }
}
