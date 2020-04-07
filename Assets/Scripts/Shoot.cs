using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{

    public AudioSource sound;

    public float projectileSpeedMultiplier = 10.0f;

    public GameObject projectilePrefab;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() {

        // Detect mouse input
        if (Input.GetMouseButtonDown(0)) {
            sound.Play();
            // Update pos to equal current position
            // Update target to equal mouse position
            Vector2 pos = rb.position;
            Vector2 target = Camera.main.ScreenToWorldPoint((Vector2)Input.mousePosition);

            // Calculate the distances
            float distX = target.x - pos.x;
            float distY = target.y - pos.y;
            float dist = Mathf.Sqrt(Mathf.Pow(distX, 2) + Mathf.Pow(distY, 2));

            // Calculate the velocities
            float velX = distX / dist * projectileSpeedMultiplier;
            float velY = distY / dist * projectileSpeedMultiplier;

            // Instantiate a new projectile at current position
            GameObject projectile = (GameObject) Instantiate(projectilePrefab, pos, Quaternion.identity);

            // Access the script of the new projectile and set its velocity
            Grav_Projectile script = (Grav_Projectile) projectile.GetComponent<Grav_Projectile>();
            script.setVel(velX + rb.velocity.x, velY + rb.velocity.y);
        }
    }
}
