using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI {
    public class ErrorView : MonoBehaviour {
        public List<string> Errors = new List<string>();

        public void SetErrors(List<string> errors) {
            ClearErrors();
            foreach (string error in errors) {
                addErrorObject(error);
            }
        }

        private void ClearErrors() {
            int numChildren = transform.childCount;
            Text[] childrenText = gameObject.GetComponentsInChildren<Text>();
            foreach (Text childText in childrenText) {
                Destroy(childText.gameObject);
            }
            Errors.Clear();
        }

        private void addErrorObject(string error) {
            GameObject errorObject = new GameObject("Error");
            errorObject.AddComponent<Text>();
            Text text = errorObject.GetComponent<Text>();
            text.text = error;
            text.font = Font.CreateDynamicFontFromOSFont("Arial", 14);
            errorObject.transform.SetParent(this.gameObject.transform);
        }
    }
}
