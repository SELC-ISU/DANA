using System;
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D bc;

    private Vector3 goalOrientation = new Vector3(0, 0, 0);

    private float horizontal;
    private bool jumpPressed;
    private bool inAir = false;
    private float groundDist;

    public float speed = 0.0f;
    public float jumpPower = 0.0f;

    private bool yellowBox = false;
    private static float JUMP_BOOST = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
		    rb = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();

        // Initializes the current orientation and goalOrientation
        goalOrientation = new Vector3(0, 0, 180 - Gravity_Shift.angle);
        transform.eulerAngles = goalOrientation;
    }

    // Update is called once per frame
    void Update()
    {
        // Checks to see if the player is trying to move
        horizontal = Input.GetAxis("Horizontal");

        // These lines of code was gotten from help forum https://answers.unity.com/questions/196381/how-do-i-check-if-my-rigidbody-player-is-grounded.html
        groundDist = GetComponent<BoxCollider2D>().bounds.extents.y;

        // Checks to see if the player is trying to jump
        if (Input.GetButton("Jump")) {
            jumpPressed = true;
        }
        if (inAir) {
            jumpPressed = false;
        }

        // Updates the goal goalOrientation to the gravity angle
        goalOrientation = new Vector3(0, 0, Gravity_Shift.angle);
    }

    void FixedUpdate() {
        // Calculates which direction to jump and which direction to walk
        float rot = (float) (Gravity_Shift.angle * Mathf.PI / 180f);
        float rotX = (float) Mathf.Cos(rot);
        float rotY = (float) Mathf.Sin(rot);

        // Rotates the player until it lines up with the gravity
        float rotationSpeed = 5;
        if (transform.eulerAngles.z + rotationSpeed < goalOrientation.z) {
            transform.Rotate(new Vector3(0.0f, 0.0f, 1.0f), rotationSpeed, Space.Self);
        } else if (transform.eulerAngles.z > rotationSpeed && transform.eulerAngles.z < 360 - rotationSpeed &&
                      transform.eulerAngles.z - rotationSpeed > goalOrientation.z) {
            transform.Rotate(new Vector3(0.0f, 0.0f, 1.0f), -rotationSpeed, Space.Self);
        } else {
            transform.eulerAngles = goalOrientation;
        }

        if (IsGrounded()) {
            inAir = false;
        } else {
            inAir = true;
        }

        // Jump logic
        if (jumpPressed && !inAir) {
      			if(yellowBox){
      				Jump(JUMP_BOOST);
      				yellowBox = false;
      			}else{
      				Jump(1.0f);
      			}
            inAir = true;
        }

        // Movement logic
        float xMovement = rotX * horizontal * speed;
        float yMovement = rotY * horizontal * speed;
        float xSpeed;
        float ySpeed;
        // Decide which x direction to fall
        if (rotY > 0) {
            xSpeed = xMovement + rb.velocity.x * rotY;
        } else {
            xSpeed = xMovement - rb.velocity.x * rotY;
        }

        // Decide which y direction to fall
        if (rotX > 0) {
            ySpeed = yMovement + rb.velocity.y * rotX;
        } else {
            ySpeed = yMovement - rb.velocity.y * rotX;
        }

        // Update velocity
        rb.velocity = new Vector2(xSpeed, ySpeed);
    }

	   private void Jump(float modifier) {
        Vector2 grav = Physics2D.gravity;
        grav.Normalize();
        if(Math.Abs(rb.velocity.x * -grav.x) < 11 && Math.Abs(rb.velocity.y * -grav.y) < 11){
			           rb.AddForce(new Vector2(rb.velocity.x + rb.mass * -grav.x * jumpPower * modifier,
                 rb.velocity.y + rb.mass * -grav.y * jumpPower * modifier),
                 ForceMode2D.Impulse);
		    }
    }

    // This method was gotten from help forum https://answers.unity.com/questions/196381/how-do-i-check-if-my-rigidbody-player-is-grounded.html
    private bool IsGrounded() {
        Vector2 raycastOrigin = new Vector2(transform.position.x, transform.position.y) + new Vector2(Physics2D.gravity.x, Physics2D.gravity.y).normalized;
        return Physics2D.Raycast(raycastOrigin, -Vector3.up, 0.0001f);
    }

    private void OnCollisionEnter2D(Collision2D col) {
        // inAir = false;

        //Notes if touching yellowBox
    		if(col.gameObject.tag == "YellowBox"){
    		    yellowBox = true;
    		}else{
    		    yellowBox = false;
    		}

        //Reloads level if it touches a RedBox
    		if(col.gameObject.tag == "RedBox"){
    		    UnityEngine.SceneManagement.SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    		}
    }

    private void OnCollisionExit2D(Collision2D col) {
        // inAir = true;
    }
}
