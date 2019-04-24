public class GameData {
    private static GameData GameDataInstance = null;

    private GameData() {

    }

    public static GameData GetInstance() {
        if (GameDataInstance == null) {
            GameDataInstance = new GameData();
        }
        return GameDataInstance;
    }
}
