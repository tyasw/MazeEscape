using UnityEngine;

public class PlayerController : MonoBehaviour {
    public GameObject Camera;
    public float MovementStep;
    public Vector3 MovementStepVector;
    public float RotationStep;
    public Vector3 RotationStepVector;
    public KeyCode PressedKey;

    private void Start() {
        MovementStep = 0.5f;
        RotationStep = 10.0f;
        MovementStepVector = new Vector3(0.0f, 0.0f, MovementStep);
        RotationStepVector = new Vector3(0.0f, RotationStep, 0.0f);
    }

    void Update () {
        PressedKey = GetKeyPressed();
        UpdatePlayerPositionAndRotation(PressedKey);
        UpdateCameraPositionAndRotation(PressedKey);
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
            newPosition = oldPosition + MovementStepVector;
            newRotation = oldRotation;
        } else if (pressedKey == KeyCode.A) {
            newPosition = oldPosition;
            newRotation = oldRotation * Quaternion.Euler(RotationStepVector);
        } else if (pressedKey == KeyCode.S) {
            newPosition = oldPosition - MovementStepVector;
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
        Vector3 cameraOldPosition = Camera.transform.position;
        Vector3 cameraNewPosition;
        Quaternion cameraOldRotation = Camera.transform.rotation;
        Quaternion cameraNewRotation;

        if (pressedKey == KeyCode.W) {
            cameraNewPosition = new Vector3(cameraOldPosition.x, cameraOldPosition.y, cameraOldPosition.z + MovementStep);
            cameraNewRotation = cameraOldRotation;
        } else if (pressedKey == KeyCode.A) {
            cameraNewPosition = new Vector3(cameraOldPosition.x - MovementStep, cameraOldPosition.y, cameraOldPosition.z);
            cameraNewRotation = cameraOldRotation;
        } else if (pressedKey == KeyCode.S) {
            cameraNewPosition = new Vector3(cameraOldPosition.x, cameraOldPosition.y, cameraOldPosition.z - MovementStep);
            cameraNewRotation = cameraOldRotation;
        } else if (pressedKey == KeyCode.D) {
            cameraNewPosition = new Vector3(cameraOldPosition.x + MovementStep, cameraOldPosition.y, cameraOldPosition.z);
            cameraNewRotation = cameraOldRotation;
        } else {
            cameraNewPosition = cameraOldPosition;
            cameraNewRotation = cameraOldRotation;
        }

        Camera.transform.SetPositionAndRotation(cameraNewPosition, Camera.transform.rotation);
    }
}
