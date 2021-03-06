﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Gravity_Shift : MonoBehaviour
{

    public AudioSource sound;

    // The current angle that gravity in the world is shifted towards
    public static float angle = 0.0f;

    // The angle of this shifter that the gravity will shift to
    public Vector3 rotation = new Vector3(0.0f, 0.0f, 0.0f);

    // Rotation variables to keep track of the relative direction
    private float rot;
    private float rotX;
    private float rotY;

    // Start is called before the first frame update
    void Start()
    {
        // Initializes the radian rotation and directions
        rot = (float) (rotation.z * Mathf.PI / 180f);
        rotX = (float) Mathf.Sin(rot);
        rotY = (float) Mathf.Cos(rot);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D entity) {
    		if(entity.gameObject.tag == "Player" || entity.gameObject.tag == "ActivatorBox") {
    			// Debug.Log(rot + "=" + rotX + "," + rotY);
    			// Updates the current world gravity angle to this gravity shifter
          float newAngle = 180 - rotation.z;
          ChangeAngle(newAngle);

    			// Updates the gravity to this gravity shifter
    			Physics2D.gravity = new Vector2(rotX * 9.81f, rotY * 9.81f);
    		}
    }

    private void ChangeAngle(float newAngle) {
        if (angle != newAngle) {
            sound.Play();
            angle = newAngle;
        }
    }
}
