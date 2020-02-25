using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using UnityEngine.SceneManagement;

public class SaveManager : MonoBehaviour
{
	
	private static string saveFolder = "./Assets/Data/";
	public static SaveInstance currentSave = new SaveInstance();
	public static int saveNum;
	
    // Start is called before the first frame update
    static void Start()
    {
        ReadSave(0, currentSave); //Loads defualt save as fallback, DO NOT ever write to 0 as it is used to reset the others to a default condition
		saveNum = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	//Loads the save number specified by numToPlay
	public void PlaySave(int numToPlay){
		ReadSave(numToPlay, currentSave);
		UnityEngine.SceneManagement.SceneManager.LoadScene(currentSave.currentLevel);
		saveNum = numToPlay;
	}
	
	public void DeleteSave(int numToDelete){
		SaveInstance blank = new SaveInstance();
		ReadSave(0, blank);
		WriteSave(numToDelete, blank);
	}
		
	
	//Used to hold save information for reading/writing to save file
	public class SaveInstance{
		public string currentLevel;
	}
	
	//Reads save numToSave from file to SaveInstance toSave
	public static void ReadSave(int numToSave, SaveInstance toSave){
		string destination = saveFolder + "save" + numToSave + ".txt";
		StreamReader reader = new StreamReader(destination);
		JsonUtility.FromJsonOverwrite(reader.ReadToEnd(), toSave);
		reader.Close();
	}
	
	//Writes SaveInstance toSave to file of save numToSave
	public static void WriteSave(int numToSave, SaveInstance toSave){
		string destination = saveFolder + "save" + numToSave + ".txt";
		StreamWriter writer = new StreamWriter(destination, false);
		writer.WriteLine(JsonUtility.ToJson(toSave));
		writer.Close();
	}
}