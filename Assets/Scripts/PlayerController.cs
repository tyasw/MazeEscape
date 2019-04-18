using UnityEngine;

public class PlayerController : MonoBehaviour {
    public GameObject Camera;

	void Start () {
		
	}
	
	void Update () {
        Vector3 oldPosition = transform.position;
        Vector3 newPosition;
        Quaternion oldRotation = transform.rotation;
        Quaternion newRotation;

        Vector3 cameraOldPosition = Camera.transform.position;
        Vector3 cameraNewPosition;
        Quaternion cameraOldRotation = Camera.transform.rotation;
        Quaternion cameraNewRotation;
        float movement = 0.5f;

        if (Input.GetKey(KeyCode.W)) {
            newPosition = new Vector3(oldPosition.x, oldPosition.y, oldPosition.z + movement);
            newRotation = oldRotation;
            cameraNewPosition = new Vector3(cameraOldPosition.x, cameraOldPosition.y, cameraOldPosition.z + movement);
            cameraNewRotation = cameraOldRotation;
        } else if (Input.GetKey(KeyCode.A)) {
            newPosition = new Vector3(oldPosition.x - movement, oldPosition.y, oldPosition.z);
            newRotation = oldRotation;
            cameraNewPosition = new Vector3(cameraOldPosition.x - movement, cameraOldPosition.y, cameraOldPosition.z);
            cameraNewRotation = cameraOldRotation;
        } else if (Input.GetKey(KeyCode.S)) {
            newPosition = new Vector3(oldPosition.x, oldPosition.y, oldPosition.z - movement);
            newRotation = oldRotation;
            cameraNewPosition = new Vector3(cameraOldPosition.x, cameraOldPosition.y, cameraOldPosition.z - movement);
            cameraNewRotation = cameraOldRotation;
        } else if (Input.GetKey(KeyCode.D)) {
            newPosition = new Vector3(oldPosition.x + movement, oldPosition.y, oldPosition.z);
            newRotation = oldRotation;
            cameraNewPosition = new Vector3(cameraOldPosition.x + movement, cameraOldPosition.y, cameraOldPosition.z);
            cameraNewRotation = cameraOldRotation;
        } else {
            newPosition = oldPosition;
            newRotation = oldRotation;
            cameraNewPosition = cameraOldPosition;
            cameraNewRotation = cameraOldRotation;
        }

        transform.SetPositionAndRotation(newPosition, newRotation);
        Camera.transform.SetPositionAndRotation(cameraNewPosition, Camera.transform.rotation);
    }
}
