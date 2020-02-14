using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Gravity_Shift : MonoBehaviour
{
    public float launchVelocity = 0.0f;

    public static int angle = 0;

    // Start is called before the first frame update
    void Start()
    {
        // Physics.gravity = new Vector3(0.0f, 0.0f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D entity) {
        float rot = transform.eulerAngles.z;
        angle = (int) rot;
        rot = (float) (rot * Mathf.PI / 180f);
        float rotX = (float) Mathf.Sin(rot);
        float rotY = (float) Mathf.Cos(rot);
        // Debug.Log(rot + "=" + rotX + "," + rotY);
        Physics2D.gravity = new Vector2(rotX * -9.81f, rotY * 9.81f);
    }

    public static int getGravityAngle() {
        return angle;
    }
}
