/** GameModel.cs
 * 
 * Holds the representation of the game state.
 */
namespace MazeEscapeLibrary.src
{
    public class GameModel
    {
        public MazeModel MazeModel { get; set; }

        public GameModel()
        {
            MazeModel = new MazeModel();
        }

        public void SetMazeWidth(int width)
        {
            MazeModel.Width = width;
        }

        public void SetMazeHeight(int height)
        {
            MazeModel.Height = height;
        }

        public int GetMazeWidth()
        {
            return MazeModel.Width;
        }

        public int GetMazeHeight()
        {
            return MazeModel.Height;
        }

        public void BeginGameWithOptionsApplied()
        {
            GetGameOptions();
            MazeController mazeController = new MazeController(MazeModel);
            mazeController.CreateMaze();
        }

        // TODO: get the options from an options file
        private void GetGameOptions()
        {
            MazeModel.CellSize = 1.0f;
        }
    }
}
