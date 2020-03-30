using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Dmg_Projectile : MonoBehaviour
{
    public float lifeSpan = 10.0f;

    Rigidbody2D rb;

    private float initTime;
    private float timeAlive;

    private Vector2 currentPos;
    private Vector2 lastPos;

    List<RaycastHit2D> colliders;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        initTime = Time.timeSinceLevelLoad;

        colliders = new List<RaycastHit2D>();

        lastPos = (Vector2) transform.position;
        currentPos = (Vector2) transform.position + rb.velocity * Time.fixedDeltaTime;
        ContactFilter2D filter = new ContactFilter2D();
        Physics2D.Linecast(lastPos, currentPos, filter, colliders);
        checkCollision();
    }

    // Update is called once per frame
    void Update()
    {
        timeAlive = Time.timeSinceLevelLoad - initTime;
        if (timeAlive > lifeSpan) {
            Destroy(this.gameObject);
        }
    }

    void FixedUpdate() {
        lastPos = currentPos;
        currentPos = (Vector2) transform.position + rb.velocity * Time.fixedDeltaTime;
        ContactFilter2D filter = new ContactFilter2D();
        Physics2D.Linecast(lastPos, currentPos, filter, colliders);

        checkCollision();
    }

    private void checkCollision() {
        if (colliders.Count > 0) {
            Transform col = colliders[0].transform;
            if (col.gameObject.tag != "Bot_Turret" &&
                  col.gameObject.tag != "Projectile") {
                Destroy(this.gameObject);
                if (col.gameObject.name == "Player") {
                    UnityEngine.SceneManagement.SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                }
            }
        }
    }

    public void setVel(float x, float y) {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(x, y);
    }

    // private void OnTriggerEnter2D(Collider2D entity) {
    //   Transform col = entity.transform;
    //     if (col.gameObject.name != "Bot_Turret" &&
    //           col.gameObject.tag != "Projectile") {
    //         Destroy(this.gameObject);
    //         if (col.gameObject.name == "Player") {
    //             // playerDist = Vector2.Distance(col.position, initPos);
    //             // wallDist
    //             UnityEngine.SceneManagement.SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    //         }
    //     }
    // }
}
