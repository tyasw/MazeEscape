﻿using System.Collections.Generic;

namespace Assets.Scripts.Events {
    public class RestartGameEvent : Subject {
        public List<Observer> Observers { get; set; }

        public RestartGameEvent() {
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
            return "RestartGameEvent";
        }
    }
}