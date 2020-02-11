using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D bc;

    private float horizontal;
    private bool jumpPressed;
    private bool inAir;

    public float speed = 0.0f;
    public float jumpPower = 1.0f;

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
    }

    void FixedUpdate() {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        if (jumpPressed && !inAir) {
            Jump();
            inAir = true;
        }
    }

    private void Jump() {
        rb.velocity = new Vector2(rb.velocity.x, jumpPower);
    }

    private void OnCollisionEnter2D(Collision2D col) {
        inAir = false;
		
		//Reloads level if it touches a RedBox
		if(col.gameObject.tag == "RedBox"){
			Application.LoadLevel(Application.loadedLevel);
		}
    }
}
