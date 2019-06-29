namespace Assets.Scripts.Maze {
    /*
     * Control when the maze model is generated.
     */
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
