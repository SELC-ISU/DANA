using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBehaviour : MonoBehaviour
{


    public Collider2D door;
    public Collider2D Player;
    public float width;
    public float height;
    public float posx;
    public float posy;
    // Start is called before the first frame update
    void Start()
    {
        width = door.gameObject.transform.localScale.x;
        height = door.gameObject.transform.localScale.y;
        posx = door.gameObject.transform.position.x;
        posy = door.gameObject.transform.position.y;
    }       

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D entity)
    {
        if (entity.gameObject.tag == "Player" || entity.gameObject.tag == "ActivatorBox")
        {
           
           
            door.gameObject.transform.localScale = new Vector2(1, 0);
            door.gameObject.transform.position = new Vector3(door.gameObject.transform.position.x, 0);
            
        }
        
    }
    void OnTriggerExit2D(Collider2D entity)
    {
        if (entity.gameObject.tag == "Player" || entity.gameObject.tag == "ActivatorBox")
        {
            //Physics2D.IgnoreCollision(door, Player);
            door.gameObject.transform.localScale = new Vector2(width,height);
            door.gameObject.transform.position = new Vector3(posx, posy);

        }
    }
}
