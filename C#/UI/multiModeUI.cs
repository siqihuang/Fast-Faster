using UnityEngine;
using System.Collections;

/*
 * used to create and manage multiplayer game
 * if the player is the host, server will be created, otherwise the server will be empty
 * no matter the server is empty or not, the client is not empty
 */ 
public class multiModeUI : playUI {
	public int mode;
	private string IP;
	private bool loadAble;
	private gameController gameInfo;
	/*
	 * need to specify IP address
	 */ 

	void Start(){
		gameMode = MULTIPLAYER;
	}

	void OnGUI(){
		GUILayout.BeginArea(new Rect(10,Screen.height/2+100,Screen.width-20,200));
		if (GUILayout.Button ("CREATE")) {
			Application.LoadLevel("createGame");
		}
		else if(GUILayout.Button ("JOIN")){
			Application.LoadLevel("joinGame");
		}
		GUILayout.EndArea ();
	}

	void Update(){

	}
}
