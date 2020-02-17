using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D bc;

    private Vector3 goalOrientation = new Vector3(0, 0, 0);

    private float horizontal;
    private bool jumpPressed;
    private bool inAir = false;

    public float speed = 0.0f;
    public float jumpPower = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");

        if (Input.GetButton("Jump")) {
            jumpPressed = true;
        }
        if (inAir) {
            jumpPressed = false;
        }
        goalOrientation = new Vector3(0, 0, Gravity_Shift.getGravityAngle());
    }

    void FixedUpdate() {
      float rot = (float) (Gravity_Shift.getGravityAngle() * Mathf.PI / 180f);
      float rotX = (float) Mathf.Cos(rot);
      float rotY = (float) Mathf.Sin(rot);

        Quaternion goalR = Quaternion.Euler(goalOrientation);
        Quaternion deltaRPos = Quaternion.Euler(goalOrientation * 2 * Time.deltaTime);
        Quaternion deltaRNeg = Quaternion.Euler(-goalOrientation * 2 * Time.deltaTime);
        if (transform.rotation.z + deltaRPos.z < goalR.z) {
            rb.MoveRotation(transform.rotation * deltaRPos);
        } else if(transform.rotation.z + deltaRNeg.z > goalR.z) {
            rb.MoveRotation(transform.rotation * deltaRNeg);
        } else {
            transform.eulerAngles = goalOrientation;
        }

        if (jumpPressed && !inAir) {
            Jump();
            inAir = true;
        } else if (!inAir) {
            rb.velocity = new Vector2(rotX * horizontal * speed, rotY * horizontal * speed);
        }
    }

    private void Jump() {
        Vector2 grav = Physics2D.gravity;
        grav.Normalize();
        rb.AddForce(new Vector2(rb.velocity.x + rb.mass * -grav.x * jumpPower,
                                rb.velocity.y + rb.mass * -grav.y * jumpPower),
                                ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D col) {
        inAir = false;

		//Reloads level if it touches a RedBox
		if(col.gameObject.tag == "RedBox"){
			Application.LoadLevel(Application.loadedLevel);
		}
    }

    private void OnCollisionExit2D(Collision2D col) {
        inAir = true;
    }
}
