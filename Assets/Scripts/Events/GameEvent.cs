namespace Assets.Scripts.Events {
    public interface GameEvent {
        EventHandler EventHandler { get; set; }

        void Trigger(GameController gameController);
    }
}
