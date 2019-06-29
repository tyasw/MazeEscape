using System;
using UnityEngine;
using System.Collections.Generic;
using Assets.Scripts.Commands;

/*
 * Runs commands. It should be attached to a GameObject in the scene. Scripts
 * that require the CommandParser will search the scene for a GameObject of
 * this type.
 */
public class CommandParser : MonoBehaviour {
    private Queue<Command> Commands { get; set; }

    private void Start() {
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
