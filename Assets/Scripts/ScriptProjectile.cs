using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptProjectile : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void setVel(float x, float y) {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(x, y);
    }
}
