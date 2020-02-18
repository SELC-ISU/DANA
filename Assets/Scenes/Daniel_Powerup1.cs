using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Daniel_Powerup1 : MonoBehaviour
{
    GameObject Circle, Box;

    // Start is called before the first frame update
    void Start()
    {
        Circle = GameObject.Find("Player_Circle");
        Box = GameObject.Find("Player");

        //start as Box
        Box.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D entity)
    {
        //changes level if it player touches it
        if (entity.gameObject.tag == "Player")
                if (Circle.active == true)
                {
                    Box.transform.position = Circle.transform.position;
                    Circle.SetActive(false);
                    Box.SetActive(true);
                }
                else if (Box.active == true)
                {
                    Circle.transform.position = Box.transform.position;
                    Box.SetActive(false);
                    Circle.SetActive(true);
                }   
    }
}
