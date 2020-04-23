using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grav_Projectile : MonoBehaviour
{

    public float lifeSpan = 10.0f;

    private float initTime;
    private float timeAlive;

    // Start is called before the first frame update
    void Start()
    {
        initTime = Time.timeSinceLevelLoad;
    }

    // Update is called once per frame
    void Update()
    {
        timeAlive = Time.timeSinceLevelLoad - initTime;
        if (timeAlive > lifeSpan) {
            Destroy(this.gameObject);
        }
    }

    public void setVel(float x, float y) {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(x, y);
    }

    private void OnTriggerEnter2D(Collider2D entity) {
        if (entity.transform.gameObject.tag != "Player" &&
              entity.transform.gameObject.tag != "Projectile" &&
              entity.transform.gameObject.tag != "GravProjectile" &&
              entity.transform.gameObject.tag != "BlackBox") {
            Destroy(this.gameObject);
        }
    }
}
