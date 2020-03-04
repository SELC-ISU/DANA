using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class nonplayer_movement : MonoBehaviour
{
    private Vector3 startPos;
    public Transform target; //this is an block selected that the platform will move to
    public float speed; //inputted speed
    private bool moveUp;
    void Start()
    {
        startPos = transform.position;
        moveUp = true;
    }
    void Update()
    {
        float step = speed * Time.deltaTime;
        //if the block has reached its target
        if (transform.position == target.position)
        {
            moveUp = false;
        }
        //if the block is at its starting position
        else if (transform.position == startPos)
        {
            moveUp = true;
        }
        //move back towards initial position
        if (moveUp == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, startPos, step);
        }
        //move towards the targeted block
        else if (moveUp)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);
        }
    }
}