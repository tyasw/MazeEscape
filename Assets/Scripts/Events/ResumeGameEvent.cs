using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Events {
    class ResumeGameEvent : MonoBehaviour, Subject {
        public List<Observer> Observers { get; set; }

        public void Attach(Observer observer) {
            Observers.Add(observer);
        }

        public void Detach(Observer observer) {
            Observers.Remove(observer);
        }

        public void Notify() {
            foreach (Observer observer in Observers) {
                observer.Update(this);
            }
        }
    }
}
