using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Events;

namespace Assets.Scripts.Commands {
    public abstract class Command : MonoBehaviour {
        public List<GameEvent> Events;

        public abstract void Run();
    }
}
