using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrownBox : MonoBehaviour
{

    private float height;

    private float goalHeight;

    public float speed = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        height = transform.localScale.y;
        goalHeight = height;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate() {
        float currentWidth = transform.localScale.x;
        float currentHeight = transform.localScale.y;

        if (Mathf.Abs(goalHeight - currentHeight) < speed) {
            transform.localScale = new Vector2(currentWidth, goalHeight);
        } else if (currentHeight < goalHeight) {
                transform.localScale = new Vector2(currentWidth, currentHeight + speed);
        } else if (currentHeight > goalHeight) {
                transform.localScale = new Vector2(currentWidth, currentHeight - speed);
        }
    }

    public void Open() {
        goalHeight = 0;
    }

    public void Close() {
        goalHeight = height;
    }
}
