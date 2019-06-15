using UnityEngine;

public class PlayerController : MonoBehaviour {
    public GameObject Camera;
    public float MovementStep;
    public float RotationStep;
    public Vector3 RotationStepVector;
    public Vector3 CameraBuffer;
    public KeyCode PressedKey;
    public PauseGame PauseGame;

    private void Start() {
        MovementStep = 0.5f;
        RotationStep = 10.0f;
        RotationStepVector = new Vector3(0.0f, RotationStep, 0.0f);
        CameraBuffer = new Vector3(0.0f, 2.0f, 0.0f);
    }

    void Update () {
        if (!PauseGame.isActiveAndEnabled) {
            PressedKey = GetKeyPressed();
            UpdatePlayerPositionAndRotation(PressedKey);
            UpdateCameraPositionAndRotation(PressedKey);
        }
    }

    private KeyCode GetKeyPressed() {
        KeyCode keyPressed;

        if (Input.GetKey(KeyCode.W)) {
            keyPressed = KeyCode.W;
        } else if (Input.GetKey(KeyCode.A)) {
            keyPressed = KeyCode.A;
        } else if (Input.GetKey(KeyCode.S)) {
            keyPressed = KeyCode.S;
        } else if (Input.GetKey(KeyCode.D)) {
            keyPressed = KeyCode.D;
        } else {
            keyPressed = KeyCode.Alpha0;
        }

        return keyPressed;
    }

    private void UpdatePlayerPositionAndRotation(KeyCode pressedKey) {
        Vector3 oldPosition = transform.position;
        Vector3 newPosition;
        Quaternion oldRotation = transform.rotation;
        Quaternion newRotation;

        if (pressedKey == KeyCode.W) {
            newPosition = oldPosition + transform.forward * MovementStep;
            newRotation = oldRotation;
        } else if (pressedKey == KeyCode.A) {
            newPosition = oldPosition;
            newRotation = oldRotation * Quaternion.Euler(RotationStepVector);
        } else if (pressedKey == KeyCode.S) {
            newPosition = oldPosition - transform.forward * MovementStep;
            newRotation = oldRotation;
        } else if (pressedKey == KeyCode.D) {
            newPosition = oldPosition;
            newRotation = oldRotation * Quaternion.Euler(-1.0f * RotationStepVector);
        } else {
            newPosition = oldPosition;
            newRotation = oldRotation;
        }

        transform.SetPositionAndRotation(newPosition, newRotation);
    }

    private void UpdateCameraPositionAndRotation(KeyCode pressedKey) {
        Vector3 cameraNewPosition = transform.position - transform.forward * 4.0f + CameraBuffer;
        Quaternion cameraNewRotation = transform.rotation * Quaternion.Euler(new Vector3(20.0f, 0.0f, 0.0f));
        Camera.transform.SetPositionAndRotation(cameraNewPosition, cameraNewRotation);
    }
}
