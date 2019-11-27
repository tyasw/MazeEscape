using UnityEngine;
using Assets.Scripts.Maze;

/*
 * Stores the data and logic related to the game. This component shuold
 * be attached to the GameObject that has a UnityController attached to it.
 */
public class GameModel : MonoBehaviour {
    public GameData GameData { get; set; }
    public MazeData MazeData { get; set; }

    private void Awake() {
        GameData = new GameData();
        MazeData = new MazeData();
    }
}
