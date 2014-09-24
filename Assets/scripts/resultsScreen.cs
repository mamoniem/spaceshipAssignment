using UnityEngine;
using System.Collections;

public class resultsScreen : MonoBehaviour {

	public string playerName;
	public int playerScore;

	public string allResults;

	public enum screenStates { EnterName, Results};
	public screenStates currentScreen;

	// Use this for initialization
	void Start () {
		currentScreen = screenStates.EnterName;
		allResults = "";

		playerScore = PlayerPrefs.GetInt("Score");

		// get all the saved keys
		for (int c=1; c<=PlayerPrefs.GetInt("playersNames"); c++){
			allResults += ("\n"+PlayerPrefs.GetString(("playerID"+ c).ToString()) + " ---------->> " + PlayerPrefs.GetInt(("playerScore"+ c).ToString()).ToString());
		}
		//show them to console
		Debug.Log(allResults);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI (){
		if (currentScreen == screenStates.EnterName){
			//enter data screen
			GUI.Label (new Rect((Screen.width/2)-80, Screen.height/2, 200, 30), "Please Insert your name...");
			playerName = GUI.TextField (new Rect((Screen.width/2)-80, (Screen.height/2)+45, 120, 30), playerName);
			if (GUI.Button (new Rect((Screen.width/2)-80, (Screen.height/2)+90, 120, 30), " Save")){
				if (playerName != null && playerName != ""){
					PlayerPrefs.SetInt("playersNames", PlayerPrefs.GetInt("playersNames")+1);
					PlayerPrefs.SetString (("playerID"+ PlayerPrefs.GetInt("playersNames")), playerName);
					PlayerPrefs.SetInt (("playerScore"+ PlayerPrefs.GetInt("playersNames")), playerScore);
					//add to the list and then switch the UI view to it
					allResults += ("\n"+PlayerPrefs.GetString(("playerID"+ PlayerPrefs.GetInt("playersNames").ToString()).ToString()) + " ---------->> " + PlayerPrefs.GetInt(("playerScore"+ PlayerPrefs.GetInt("playersNames").ToString()).ToString()).ToString());
					currentScreen = screenStates.Results;
				}
			}
			if (GUI.Button (new Rect((Screen.width/2)-80, (Screen.height/2)+180, 120, 30), " Restart")){
				Application.LoadLevel("gameScene");
			}
		}else{
			GUILayout.Label (allResults);
			GUILayout.Space(30);
			if (GUILayout.Button("Clear Saved List")){
				//just in case the used want to reset the saved data
				PlayerPrefs.DeleteAll();
			}
			if (GUILayout.Button("Restart")){
				Application.LoadLevel("gameScene");
			}
		}
	}
}
