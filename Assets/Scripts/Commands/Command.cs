using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Commands {
    public abstract class Command : MonoBehaviour {
        public List<Subject> Subjects;

        public virtual void Run() {
            foreach (Subject Subject in Subjects) {
                Subject.Notify();
            }
        }
    }
}
