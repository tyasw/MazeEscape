using System;
using System.Collections.Generic;

namespace MazeEscape.src
{
    public class CommandParser
    {
        private Queue<Command> Commands { get; set; }

        public CommandParser()
        {
            Commands = new Queue<Command>();
        }

        public void AddCommand(Command command)
        {
            if (command == null)
            {
                throw new ArgumentNullException();
            }
            Commands.Enqueue(command);
        }

        public void RunNextCommand()
        {
            Command command = RemoveCommandFromQueue();

            try
            {
                command.Run();
            } catch (NullReferenceException nre)
            {
                throw new Exception();
            }
        }

        private Command RemoveCommandFromQueue()
        {
            Command nextCommand = null;
            if (Commands.Count > 0)
            {
                nextCommand = Commands.Dequeue();
            }
            return nextCommand;
        }
    }
}
