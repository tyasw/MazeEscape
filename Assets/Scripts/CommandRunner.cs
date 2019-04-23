using UnityEngine;

public class CommandRunner {
    private CommandParser CommandParser { get; set; }

    public CommandRunner(CommandParser commandParser) {
        CommandParser = commandParser;
    }

    public void RunNextCommand() {
        string commandName = CommandParser.RunNextCommand();
        if (commandName != "") {
            Debug.Log(commandName + " was just run");
        }
    }
}
