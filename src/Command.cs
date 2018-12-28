/** Command.cs
 * 
 * A command that performs some action, such as starting a new game or pausing
 * a game in progress.
 */
namespace MazeEscapeLibrary.src
{
    public interface Command
    {
        void Run();
    }
}
