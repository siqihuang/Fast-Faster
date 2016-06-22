using UnityEngine;
using System.Collections;

public class modeSceneUI : MonoBehaviour {
	server s;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI(){
		GUILayout.BeginArea(new Rect(10,Screen.height/2+100,Screen.width-20,200));
		if (GUILayout.Button ("Single")) {
			Application.LoadLevel("mainScene");
		}
		if(GUILayout.Button ("Multiple")){

			Application.LoadLevel("multiModeScene");
		}
		GUILayout.EndArea ();
	}
}
