using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{

    public GameObject projectile;
    private Vector2 target;
    private Vector2 pos;

    // Start is called before the first frame update
    void Start()
    {
        target = new Vector2(0.0f, 0.0f);
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            target = Camera.main.ScreenToWorldPoint((Vector2)Input.mousePosition);
            Debug.Log("Target: " + target);
            Instantiate(projectile, new Vector3(0, 0, 0), Quaternion.identity);
        }
    }
}
