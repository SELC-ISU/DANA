using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using UnityEngine.SceneManagement;

public class SaveManager : MonoBehaviour
{
	
	//Current Save Information
	public static string saveFolder;
	public static SaveInstance currentSave = new SaveInstance();
	public static int saveNum;
	
	//Blank/Template Save Information
	public static SaveInstance template = new SaveInstance();
	
    // Start is called before the first frame update
    void Start()
    {
		saveNum = 1; //Sets default save folder
		JsonUtility.FromJsonOverwrite("{\"currentLevel\":\"Level 1\"}", template); //Blank/Template Save Information

		//Creates save folder in Application.persistentDataPath if it doesn't exist
		saveFolder = Application.persistentDataPath + "/Saves/";
		Debug.Log(saveFolder);
		if(!Directory.Exists(saveFolder)){
			Directory.CreateDirectory(saveFolder);
		}
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
	
	//Adds blank/default save to file
	public void DeleteSave(int numToDelete){
		WriteSave(numToDelete, template);
	}
		
	
	//Used to hold save information for reading/writing to save file
	public class SaveInstance{
		public string currentLevel;
	}
	
	//Reads save numToSave from file to SaveInstance toSave
	public static void ReadSave(int numToSave, SaveInstance toSave){
				Debug.Log(saveFolder);

		saveFileExists(numToSave);
		
		string destination = saveFolder + "save" + numToSave + ".txt";
		StreamReader reader = new StreamReader(destination);
		JsonUtility.FromJsonOverwrite(reader.ReadToEnd(), toSave);
		reader.Close();
	}
	
	//Writes SaveInstance toSave to file of save numToSave
	public static void WriteSave(int numToSave, SaveInstance toSave){
		
		saveFileExists(numToSave);

		string destination = saveFolder + "save" + numToSave + ".txt";
		StreamWriter writer = new StreamWriter(destination, false);
		writer.WriteLine(JsonUtility.ToJson(toSave));
		writer.Close();
	}
	
	//Helper method to create save file if it doesn't exist
	public static void saveFileExists(int numToSave){
		if(!File.Exists(saveFolder + "save" + numToSave + ".txt")){
			File.Create(saveFolder + "save" + numToSave + ".txt").Dispose(); //.Dispose() closes the file right away for prompt editing, otherwise gives sharing violation error
			SaveManager temp = new SaveManager();
			temp.DeleteSave(numToSave); //Adds blank/defualt save to file
		}
	}
}