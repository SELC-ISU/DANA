using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Hint_Text : MonoBehaviour
{
	
	public GameObject hintPrefab; //Hint Prefab
	private GameObject hintPrefabInstance;
	private float timerLength = 7f; //Timer length in seconds
	private float startTime;
	
	private class Hint{ //Hint class
		public string level;
		public string text;
		
		public Hint(string level, string text){
			this.level = level;
			this.text = text;
		}
	}
	
	//Add level hints/text here
	static Hint[] hints = new Hint[]{
		new Hint("Level 1", "Use A/D or Left/Right Arrow keys to move sideways, and space to jump. Avoid the red blocks and touch the green ones to complete the level."),
		new Hint("Level 2", "Yellow blocks are bouncy and can be used to jump higher."),
		new Hint("Level 3", "Touching the purple blocks will switch gravity to the direction the arrow is facing."),
		new Hint("Level 4", "You can exit to menu or restart the level by pressing escape (Esc)."),
		new Hint("Level 5", "The R key is a shortcut to restart levels."),
		new Hint("Level 6", "The pink circle can be used to switch your character from a square to a smaller circle. This will allow you to fit in smaller spaces."),
		new Hint("Level 7", "White blocks have physics and can be moved and pushed around. Be careful not to hit the red blocks though!"),
		new Hint("Level 8", "By clicking your mouse, you can shoot at black blocks to change the direction of gravity as well. Try shooting the ceiling."),
		new Hint("Level 10", "Brown doors can be opened by pressing the orange button. Light blue blocks can also be used to activate these buttons."),
		new Hint("Level 13", "Light green blocks are portals. Stepping into one will place the player on the other side."),
		new Hint("Level 17", "Some platforms can move. Landing on them will move you relative to the platform's movement."),
		new Hint("Level 19", "Pink blocks are automated turrets. Be careful not to get hit by their bullets!")
	};
	
    // Start is called before the first frame update
    void Start()
    {
		startTime = Time.time;
		
		hintPrefabInstance = Instantiate(hintPrefab, new Vector3(0, 0, 0), Quaternion.identity); //Creates hint/text
		Text hintText = hintPrefabInstance.gameObject.GetComponentInChildren<Text>();
		
		hintText.text = "";
        for(int i = 0; i < hints.Length; i++){
			if(hints[i].level == SceneManager.GetActiveScene().name){
				hintText.text = hints[i].text;
			}
		}
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > startTime + timerLength){
			Destroy(hintPrefabInstance);
		}
    }
}
