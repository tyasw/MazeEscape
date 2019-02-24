/** MazeController.cs
 * 
 * Handles the creation of a maze.
 */
namespace MazeEscape.src {
    public class MazeController {
        private MazeModel Model { get; set; }

        public MazeController(MazeModel model) {
            Model = model;
        }

        public void CreateMaze() {
            Model.CreateMaze();
        }
    }
}
