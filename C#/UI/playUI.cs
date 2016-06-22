using UnityEngine;
using System.Collections;

/*
 * this is the class to be inherit by singleModeUi and multiModeUI
 * it should implement the function of choose car, choose character, choose difficulty
 * these function can be achieved by switching camera to different places in the scene
 */ 
public class playUI : MonoBehaviour {
	private int carID,characterID,difficulty;
	protected int gameMode,computerNum,playerNum;
	public static int SINGLEPLAYER=0,MULTIPLAYER=1;

	// Use this for initialization
	/*void Start () {

	}*/
	
	// Update is called once per frame
	void Update () {
	
	}

	protected void chooseCar(){
		//TODO
	}

	protected void chooseCharacter(){
		//TODO
	}

	protected void chooseDifficulty(){
		//TODO
	}

	protected void setting(){}
}
