using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Events {
    /*
     * The central authority for event handling. Clients register a listener.
     * Another client will fire the event, which will cause all listeners
     * who are listening to that event to be notified.
     */
    public class CustomEventSystem : MonoBehaviour {
        public delegate void EventListener();
        Dictionary<System.Type, List<EventListener>> eventListeners;

        public void RegisterListener(System.Type eventType, EventListener listener) {
            if (eventListeners == null) {
                eventListeners = new Dictionary<Type, List<EventListener>>();
            }

            if (eventListeners.ContainsKey(eventType) == false || eventListeners[eventType] == null) {
                eventListeners[eventType] = new List<EventListener>();
            }

            eventListeners[eventType].Add(listener);
        }

        public void UnregisterListener(System.Type eventType, EventListener listener) {
            if (eventListeners == null || !eventListeners.ContainsKey(eventType)) {
                return;
            }

            eventListeners[eventType].Remove(listener);
        }

        public void FireEvent(System.Type eventType) {
            if (eventListeners == null || eventListeners[eventType] == null) {
                // No one is listening
                return;
            }

            foreach (EventListener listener in eventListeners[eventType]) {
                listener();
            }
        }
    }
}
