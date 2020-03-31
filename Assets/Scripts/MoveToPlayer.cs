using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToPlayer : MonoBehaviour
{
    private Vector3 startPos;
    private GameObject player;
    public GameObject whatMoves;
    public Transform target; //this is an block selected that the platform will move to
    public float speed; //inputted speed
    private bool moveToPlayer;
    // Start is called before the first frame update
    void Start()
    {
        startPos = whatMoves.transform.position;
        player = GameObject.FindWithTag("Player");
        moveToPlayer = false;
    }


    // Update is called once per frame
    void Update()
    {
        player = GameObject.FindWithTag("Player");

        //how far to move
        float step = speed * Time.deltaTime;
        //if the block has reached its target
        if (whatMoves.transform.position == target.position)
        {
            moveToPlayer = false;
        }
        if (moveToPlayer == false && whatMoves.transform.position != startPos)
        {
            whatMoves.transform.position = Vector3.MoveTowards(whatMoves.transform.position, startPos, step);
        }
        //move whatMoves towards the targeted block
        else if (moveToPlayer)
        {
            whatMoves.transform.position = Vector3.MoveTowards(whatMoves.transform.position, target.position, step);
        }

    }
    void onTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject == player)
        {
            moveToPlayer = true;
            player.transform.position = startPos;
        }
    }
}
