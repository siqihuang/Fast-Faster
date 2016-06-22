using UnityEngine;
using System.Collections;
using System.Threading;

public class startMenu : MonoBehaviour {
	public GUIStyle buttonStyle;
	private server s;
	private client c;
	// Use this for initialization
	void Start () {
		//s = new server (1);
		//c = new client ("127.0.0.1");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI(){
		GUILayout.BeginArea(new Rect(10,Screen.height/2+100,Screen.width-20,200));
		if (GUILayout.Button ("New Game")) {
		
		}
		if(GUILayout.Button ("Instruction")){
			Application.LoadLevel("instructionScene");
		}
		if (GUILayout.Button ("High Score")) {
			Application.LoadLevel("highScoreScene");
		}
		if(GUILayout.Button("Exit")){
			Application.Quit();
		}
		GUILayout.EndArea ();
	}
}
