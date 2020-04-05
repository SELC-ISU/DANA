using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private int coinsCollected;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            //if the player gets the coin, increase coin amount and make the coin disappear
            Destroy(this.gameObject);
            coinsCollected++;
            CoinScore.instance.GainCoins(1);
        }
    }
}
