using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    public GameObject player;
    public Vector2 offset = new Vector2(0, 0);

    private Vector3 relativePosition;
    private Vector3 goalOrientation = new Vector3(0, 0, 0);
    public int rotationSpeed = 1;

    // Start is called before the first frame update
    void Start()
    {
        relativePosition = new Vector3(offset.x, offset.y, -10);
    }

    // Update is called once per frame
    void Update()
    {
        // Updates the position to equal the player's position plus an offset
        transform.position = player.transform.position + relativePosition;
        // Updates the current goal orientation based on the gravity direction
        goalOrientation = new Vector3(0, 0, Gravity_Shift.angle);
    }

    void FixedUpdate() {
      // Rotates the camera until it lines up with the gravity
        if (transform.eulerAngles.z + rotationSpeed < goalOrientation.z) {
            transform.Rotate(new Vector3(0.0f, 0.0f, 1.0f), rotationSpeed, Space.Self);
        } else if (transform.eulerAngles.z - rotationSpeed > goalOrientation.z) {
            transform.Rotate(new Vector3(0.0f, 0.0f, 1.0f), -rotationSpeed, Space.Self);
        } else {
            transform.eulerAngles = goalOrientation;
        }
    }
}
