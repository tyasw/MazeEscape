using Assets.Scripts.Commands;

public class EventHandler {
    private static EventHandler EventHandlerInstance = null;
    private CommandParser CommandParser { get; set; }

    private EventHandler() {
        CommandParser = CommandParser.GetInstance();
    }

    public static EventHandler GetInstance() {
        if (EventHandlerInstance == null) {
            EventHandlerInstance = new EventHandler();
        }
        return EventHandlerInstance;
    }

    public void Notify(Command command) {
        CommandParser.AddCommand(command);
        CommandParser.RunNextCommand();
    }
}