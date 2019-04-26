using System.Collections.Generic;

public abstract class Subject {
    private List<Observer> Observers { get; set; }

    public abstract void Attach(Observer observer);
    public abstract void Detach(Observer observer);
    public abstract void Notify();
}
