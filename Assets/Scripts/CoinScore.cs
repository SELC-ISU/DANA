using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinScore : MonoBehaviour
{
    public static CoinScore instance;
    public Text coinText;
    int coins;
    public int totalCoins;
    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        coinText.text = "Coins: 0/" + totalCoins;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GainCoins(int coinsGained)
    {
        coins += coinsGained;
        coinText.text = "Coins: " + coins + "/" + totalCoins; 
    }
}
