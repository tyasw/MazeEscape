using System.Collections.Generic;

public class GameData : Subject {
    public bool GameWon { get; set; }
    public List<Observer> Observers { get; set; }

    public GameData() {
        GameWon = false;
        Observers = new List<Observer>();
    }

    public void Attach(Observer observer) {
        Observers.Add(observer);
    }

    public void Detach(Observer observer) {
        Observers.Remove(observer);
    }

    public void Notify() {
        foreach (Observer observer in Observers) {
            observer.UpdateObserver(this);
        }
    }

    public override string ToString() {
        return "GameData";
    }
}
