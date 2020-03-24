using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IngameMenu : MonoBehaviour
{
	private static bool menuOpen = false;
	public GameObject ingameMenuPrefab;
	private GameObject ingameMenuInstance;
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && gameObject.tag == "Player"){ //Check if player has pressed escape
			if(menuOpen){
				Destroy(ingameMenuInstance);
			}else{
				ingameMenuInstance = Instantiate(ingameMenuPrefab, new Vector3(0, 0, 0), Quaternion.identity);
			}
			menuOpen = !menuOpen;
		}
    }
	
	public void restartLevel(){ //Called to restart level
		UnityEngine.SceneManagement.SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		menuOpen = false;
	}
	
	public void mainMenu(){ //Called to open main menu
		UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
		menuOpen = false;
	}
}
