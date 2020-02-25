using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter_2 : MonoBehaviour
{
    GameObject tp1, tp2, player;
    Vector3 p1, p2;
    // Start is called before the first frame update
    void Start()
    {
        tp1 = GameObject.Find("Teleporter");
        tp2 = GameObject.Find("TP2");
        player = GameObject.FindWithTag("Player");
        p1 = tp1.transform.position;
        p2 = tp2.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
    }

    //if player touches it
    void OnTriggerEnter2D(Collider2D entity)
    {
        if (entity.gameObject == player)
        {
            player.transform.position = p1;
        }
    }
}