using UnityEngine;
using System.Collections;
using System.IO;

/*
 * the script is attached to an empty object
 * it is responsible for reading file and show the high score of history players
 */ 
public class highScoreUI : MonoBehaviour {
	private readFile read;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	/*
	 * read file from a string and put it into the data buffer
	 * you should design the data structure yourself
	 */ 
	bool loadFile(string fileName){
		return true;
	}
}
