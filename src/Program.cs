using System;

/** MazeTest.cs
 * 
 * Author: William Tyas
 * Description: MazeTest is a game where users find their way through a maze.
 */
namespace MazeEscapeLibrary.src
{
    public class Program
    {
        public static int MazeWidth { get; set; }
        public static int MazeHeight { get; set; }

        static void Main(string[] args)
        {
            GameController gameController = new TextController();
            gameController.Start();
        }
    }
}
