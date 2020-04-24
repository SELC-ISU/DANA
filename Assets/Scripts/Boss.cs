using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{

    private Vector3 goalOrientation = new Vector3(0, 0, 0);
    private float goalX;

    private float speed = 0.1f;
    private float lives = 3;

    public GameObject[] legs1;
    public GameObject[] legs2;
    public GameObject[] legs3;

    public GameObject door1;
    public GameObject door2;
    public GameObject door3;
    public GameObject door0;

    // Start is called before the first frame update
    void Start()
    {
        goalX = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate() {

        float currentX = transform.position.x;
        float currentY = transform.position.y;

        if (Mathf.Abs(goalX - currentX) < speed) {
            transform.position = new Vector2(goalX, currentY);
        } else if (currentX < goalX) {
                transform.position = new Vector2(currentX + speed, currentY);
        } else if (currentX > goalX) {
                transform.position = new Vector2(currentX - speed, currentY);
        }
        if (transform.position.x < -45) {
            GameObject.FindWithTag("MainCamera").GetComponent<FollowPlayer>().SetTarget(transform.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.tag == "RedBox") {
            if (lives > 0) {
                GameObject.Destroy(col.gameObject);
            }
            if (lives == 3) {
                for (int i = 0; i < legs1.Length; i++) {
                    GameObject.Destroy(legs1[i]);
                }
                door1.GetComponent<BrownBox>().Open();
            }
            if (lives == 2) {
                for (int i = 0; i < legs2.Length; i++) {
                    GameObject.Destroy(legs2[i]);
                }
                door2.GetComponent<BrownBox>().Open();
            }
            if (lives == 1) {
                for (int i = 0; i < legs3.Length; i++) {
                    GameObject.Destroy(legs3[i]);
                }
                door3.GetComponent<BrownBox>().Open();
            }
            if (lives == 0) {
                door0.GetComponent<BrownBox>().Open();
                GameObject.Destroy(transform.gameObject);
            }
            lives--;
        }
    }


}
