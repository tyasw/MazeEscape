using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI {
    public class ErrorView : MonoBehaviour {
        private List<string> errors = new List<string>();

        private void Start() {
            foreach (string error in errors) {
                GameObject errorObject = new GameObject("Error");
                errorObject.AddComponent<Text>();
                Text text = errorObject.GetComponent<Text>();
                text.text = error;
                text.font = Font.CreateDynamicFontFromOSFont("Arial", 14);
                errorObject.transform.SetParent(this.gameObject.transform);
            }
        }
    }
}
