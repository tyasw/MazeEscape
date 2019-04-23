using System;
using System.Collections.Generic;
using Assets.Scripts.Commands;

public class CommandParser {
    private Queue<Command> Commands { get; set; }

    public CommandParser() {
        Commands = new Queue<Command>();
    }

    public void AddCommand(Command command) {
        if (command == null) {
            throw new ArgumentNullException();
        }
        Commands.Enqueue(command);
    }

    public string RunNextCommand() {
        Command command = RemoveCommandFromQueue();
        string commandName = "";

        if (command != null) {
            command.Run();
            commandName = command.ToString();
        }
        return commandName;
    }

    private Command RemoveCommandFromQueue() {
        Command nextCommand = null;
        if (Commands.Count > 0) {
            nextCommand = Commands.Dequeue();
        }
        return nextCommand;
    }
}
