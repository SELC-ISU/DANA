using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBehaviour : MonoBehaviour
{


    public Collider2D door;
    public Collider2D Player;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D entity)
    {
        if (entity.gameObject.tag == "Player")
        {
            Physics2D.IgnoreCollision(door, Player);
        }
        void OnTriggerExit2D(Collider2D other)
        {
            if (entity.gameObject.tag == "Player")
            {
                Physics2D.IgnoreCollision(door, Player);
            }
        }
    }
}
