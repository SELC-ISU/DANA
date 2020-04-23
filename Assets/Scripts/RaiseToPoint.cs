using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaiseToPoint : MonoBehaviour
{

    public float goalHeight = 0.0f;
    public float speed = 0.1f;

    private float height;

    // Start is called before the first frame update
    void Start()
    {
        height = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate() {
        float currentX = transform.position.x;
        float currentY = transform.position.y;

        if (Mathf.Abs(goalHeight - currentY) < speed) {
            transform.position = new Vector2(currentX, goalHeight);
        } else if (currentY < goalHeight) {
                transform.position = new Vector2(currentX, currentY + speed);
        } else if (currentY > goalHeight) {
                transform.position = new Vector2(currentX, currentY - speed);
        }
    }
}
