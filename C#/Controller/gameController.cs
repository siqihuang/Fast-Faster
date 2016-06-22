using UnityEngine;
using System.Collections;

/*
 * it controls the global information of the game scene.
 * it controls the event(volcano,stone,thunder,spike..)
 * it controls the props(protection,bomb,acceleration..)
 * it controls the car()
 */ 
public class gameController :MonoBehaviour{
	private int gameMode, carNum, carID;
	private propsController propControl;
	private eventController eventControl;
	private carController[] carControl;
	private cameraController cameraControl;
	public GameObject playerCars,internetCars,computerCars;
	private multiModeUI multiMode;
	private client c;

	void Start(){
		GameObject obj = GameObject.Find ("client");

		if(obj!=null){
			c = obj.GetComponent<client> ();
			c.setGameInfo (this);
			this.createCars (c.getPlayerNum (), c.getPlayerID (),multiModeUI.MULTIPLAYER);
			c.sendCarReady ();//signal to tell server it is ready
		}
		else{
			this.createCars (1, 0,multiModeUI.SINGLEPLAYER);
		}
		//this.createCars (1, 0);
		//GameObject obj=Instantiate(playerCars,new Vector3(550,-30,550),Quaternion.identity) as GameObject;
	}

	public void moveForwardCar(int carID){
		if(this.carID!=carID)
			carControl [carID].moveForwardCar ();
	}

	public void moveBackwardCar(int carID){
		if(this.carID!=carID)
			carControl [carID].moveBackwardCar ();
	}

	public void rotateLeft(int carID){
		if(this.carID!=carID)
			carControl [carID].rotateLeft ();
	}

	public void rotateRight(int carID){
		if(this.carID!=carID)
			carControl [carID].rotateRight ();
	}

	public void setRunnable(){
		carControl [carID].runnable = true;
	}

	public void setPosition(int carID, Vector3 pos){
		carControl [carID].transform.position = pos;
	}

	public void setRotation(int carID, Quaternion rot){
		carControl [carID].rigidbody.rotation = rot;
	}

	public void fireProps(int carID){
	}

	public void createCars(int carNum,int carID,int mode){
		this.carNum = carNum;
		this.carID = carID;
		carControl = new carController[carNum];
		Vector3 position;
		for(int i=0;i<carNum;i++){
			position=new Vector3(280+10*i,30,280-10*i);
			if(i!=carID){
				if(mode==multiModeUI.SINGLEPLAYER){
					GameObject obj=Instantiate(computerCars,position,Quaternion.identity) as GameObject;
					carControl[i]=obj.GetComponent<computerCar>();
				}
				else{
					GameObject obj=Instantiate(internetCars,position,Quaternion.identity) as GameObject;
					carControl[i]=obj.GetComponent<internetCar>();
				}
				carControl[i].setCarID(i);
			}
			else{
				GameObject obj=Instantiate(playerCars,position,Quaternion.identity) as GameObject;
				carControl[i]=obj.GetComponent<playerCar>();
				carControl[i].setCarID(i);
				carControl[i].runnable=true;
			}
		}
	}
}