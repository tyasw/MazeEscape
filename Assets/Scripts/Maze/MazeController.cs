namespace Assets.Scripts.Maze {
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
