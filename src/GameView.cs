/** GameView.cs
 * 
 * An interface for controlling what gets displayed to the user.
 */
namespace MazeEscapeLibrary.src
{
    public interface GameView
    {
        GameModel GameModel { get; set; }
        int MazeWidth { get; set; }
        int MazeHeight { get; set; }
        MazeTransformer MazeTransformer { get; set; }

        // Present the maze to the user
        void ShowMaze();
    }
}
