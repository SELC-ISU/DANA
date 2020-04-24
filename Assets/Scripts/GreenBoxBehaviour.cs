using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class GreenBoxBehaviour : MonoBehaviour
{
	private string[] levelNames = {"Level 1", "Level 2", "Level 3", "Level 4", "Level 5", "Level 6", "Level 7", "Level 8", "Level 9", "Level 10", "Level 11", "Level 12", "Level 13", "Level 14", "Level 15", "Level 16", "Level 17", "Level 18", "Level 19", "Level 20", "Level 21", "Boss Level 1", "Boss Level 2", "Boss Level 3"};
    public int coinsToWin;
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
        //changes level if it player touches it
        if (entity.gameObject.tag == "Player" && CoinScore.instance.getCoins() >= coinsToWin)
        {
			int index = Array.IndexOf(levelNames, SceneManager.GetActiveScene().name);
			if(index > -1 && index != levelNames.Length - 1){
				SaveManager.currentSave.currentLevel = levelNames[++index];
				SaveManager.currentSave.coinsGathered += CoinScore.instance.getCoins();
				SaveManager.WriteSave(SaveManager.saveNum, SaveManager.currentSave);
				UnityEngine.SceneManagement.SceneManager.LoadScene(levelNames[index]);
			}else{
				UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
			}
        }
    }
}
