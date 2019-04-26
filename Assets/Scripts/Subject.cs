using System.Collections.Generic;

public interface Subject {
    List<Observer> Observers { get; set; }

    void Attach(Observer observer);
    void Detach(Observer observer);
    void Notify();
}
