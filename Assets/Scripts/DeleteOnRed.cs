using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteOnRed : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D col) {
        //Reloads level if it touches a RedBox
        if(col.gameObject.tag == "RedBox") {
            Destroy(this.gameObject);
        }
    }
}
