using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class GreenBoxBehaviour : MonoBehaviour
{
	string[] levelNames = {"KenyonTestLevel1", "Daniel_PowerupLevel", "Yellow_Block_Level", "KenyonTestLevel3"};
	
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
        if (entity.gameObject.tag == "Player")
        {
			int index = Array.IndexOf(levelNames, SceneManager.GetActiveScene().name);
			if(index > -1 && index != levelNames.Length - 1){
				UnityEngine.SceneManagement.SceneManager.LoadScene(levelNames[++index]);
			}else{
				UnityEngine.SceneManagement.SceneManager.LoadScene("GreenBox_Test2");
			}
        }
    }
}
