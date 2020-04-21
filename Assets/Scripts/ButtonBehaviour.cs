using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBehaviour : MonoBehaviour
{

    // public GameObject player;
    public GameObject[] doors;

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
        if (entity.gameObject.tag == "Player" || entity.gameObject.tag == "ActivatorBox") {
            foreach (GameObject door in doors) {
                door.GetComponent<BrownBox>().Open();
            }
        }

    }
    void OnTriggerExit2D(Collider2D entity)
    {
        if (entity.gameObject.tag == "Player" || entity.gameObject.tag == "ActivatorBox") {
            foreach (GameObject door in doors) {
                door.GetComponent<BrownBox>().Close();
            }
        }
    }
}
