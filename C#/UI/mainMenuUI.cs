using UnityEngine;
using System.Collections;

/*
 * the class is attached to an empty object
 * it can load five scenes and also exit the game
 * it is the first scene of the game
 */
public class mainMenuUI : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	/*
	 * the function implements the five scenes. using GUILayout
	 * the scene name are 'instruction','option','store','play','highscore'
	 * you also need to implement exit
	 */
	void OnGUI(){
		GUILayout.BeginArea(new Rect(10,Screen.height/2+100,Screen.width-20,200));
		if (GUILayout.Button ("New Game")) {
			Application.LoadLevel("modeScene");
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
