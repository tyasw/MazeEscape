using UnityEngine;

namespace Assets.Scripts.Commands {
    /*
     * Fires an event when run.
     */
    public abstract class Command : MonoBehaviour {
        public abstract void Run();
    }
}
