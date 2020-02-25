using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{

    public GameObject projectilePrefab;
    private GameObject projectile;
    // private Projectile script;

    private Vector2 target;
    private Vector2 pos;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = new Vector2(0.0f, 0.0f);
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            pos = rb.position;
            target = Camera.main.ScreenToWorldPoint((Vector2)Input.mousePosition);
            float velX = target.x - pos.x;
            float velY = target.y - pos.y;
            Vector2 vel = new Vector2(velX, velY);

            Debug.Log("Target: " + target);

            projectile = (GameObject) Instantiate(projectilePrefab, pos, Quaternion.identity);

            ScriptProjectile script = (ScriptProjectile) projectile.GetComponent<ScriptProjectile>();
            // Debug.Log(script);
            script.setVel(velX, velY);
        }
    }
}
