using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeEscapeLibrary.src
{
    public class CommandParser
    {
        public GameController GameController;
        public GameModel GameModel;

        private Queue<Command> Commands { get; set; }

        public CommandParser(GameController controller, GameModel model)
        {
            GameController = controller;
            GameModel = model;
            Commands = new Queue<Command>();
            AddCommand(new ShowNewGameOptionsCommand(GameController));
            AddCommand(new BeginGameCommand(GameController, GameModel));
        }

        public void AddCommand(Command command)
        {
            Commands.Enqueue(command);
        }

        public void RunNextCommand()
        {
            Command command = RemoveCommandFromQueue();
            if (command != null)
            {
                command.Run();
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
