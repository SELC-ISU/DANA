using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bot_Shoot : MonoBehaviour
{

    public float projectileSpeedMultiplier = 10.0f;

    public GameObject projectilePrefab;
    public GameObject targetObject;

    private float lastTime;
    private float currentTime;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentTime = Time.timeSinceLevelLoad;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentTime - lastTime > 0.1f) {
            lastTime = currentTime;
            shoot();
        }
        currentTime = Time.timeSinceLevelLoad;
    }

    private void shoot() {
        // Update pos to equal current position
        // Update target to equal mouse position
        Vector2 pos = rb.position;
        Vector2 target = targetObject.GetComponent<Rigidbody2D>().position;

        // Calculate the distances
        float distX = target.x - pos.x;
        float distY = target.y - pos.y;
        float dist = Mathf.Sqrt(Mathf.Pow(distX, 2) + Mathf.Pow(distY, 2));

        // Calculate angle at which projectile is fired
        float angle = Mathf.Atan2(distY, distX) * Mathf.Rad2Deg;

        // Calculate the velocities
        float velX = distX / dist * projectileSpeedMultiplier;
        float velY = distY / dist * projectileSpeedMultiplier;

        // Instantiate a new projectile at current position
        GameObject projectile = (GameObject) Instantiate(projectilePrefab, pos, Quaternion.identity);
        projectile.transform.Rotate(0, 0, angle);
        // projectile.GetComponent<BoxCollider2D>().size = new Vector2(projectileSpeedMultiplier * 0.2f, projectile.transform.localScale.y);
        projectile.transform.localScale = new Vector2(projectileSpeedMultiplier * 0.01f, projectile.transform.localScale.y);

        // Access the script of the new projectile and set its velocity
        Dmg_Projectile script = (Dmg_Projectile) projectile.GetComponent<Dmg_Projectile>();
        script.setVel(velX, velY);
    }
}
