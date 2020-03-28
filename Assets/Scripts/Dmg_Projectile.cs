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

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        initTime = Time.timeSinceLevelLoad;
        currentPos = (Vector2) transform.position + rb.velocity * Time.fixedDeltaTime;
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
        List<RaycastHit2D> colliders = new List<RaycastHit2D>();
        ContactFilter2D filter = new ContactFilter2D();
        /* linecasting */
        lastPos = currentPos;
        currentPos = (Vector2) transform.position + rb.velocity * Time.fixedDeltaTime;
        Physics2D.Linecast(lastPos, currentPos, filter, colliders);

        if (colliders.Count > 0) {
            // Transform col = getClosestObject(colliders);
            Transform col = colliders[0].transform;
            if (col.gameObject.name != "Bot_Turret" &&
                  col.gameObject.tag != "Projectile") {
                Destroy(this.gameObject);
                if (col.gameObject.name == "Player") {
                    // playerDist = Vector2.Distance(col.position, initPos);
                    // wallDist
                    UnityEngine.SceneManagement.SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                }
            }
        }
    }

    private Transform getClosestObject(List<RaycastHit2D> list) {
        float shortestDist = float.MaxValue;
        Transform closestObject = list[0].transform;
        foreach (RaycastHit2D hit in list) {
              float dist = Vector2.Distance(lastPos, hit.transform.position);
              if (dist < shortestDist) {
                  shortestDist = dist;
                  closestObject = hit.transform;
              }
        }
        return closestObject;
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
