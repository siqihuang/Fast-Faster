using UnityEngine;
using System.Collections;

/*
 * this script is responsible for handling event of the car
 * it needs to handle props
 * it needs to handle events
 */ 

public class playerCar : carController {
	private int health,firedPropsType;
	private float lastHeight,newHeight;
	private Vector3 lastSpeed,newSpeed;
	private CostumGUI GUI;
	private GameObject obj;
	private client c;

	// Use this for initialization
	new void Start () {
		base.Start ();
		prop1 = prop2 = -1;
		health = 100;
		time = 0;
		deltaTime = 0;

		obj = GameObject.Find ("client");
		if(obj!=null) c = obj.GetComponent<client> ();

		obj = GameObject.Find ("GUI Text");
		GUI = obj.GetComponent<CostumGUI> ();
		GUI.setData (health, time, prop1, prop2);
		GUI.showUI ();
	}
	
	// Update is called once per frame
	void Update () {
		if(runnable){
			deltaTime += Time.deltaTime;
			if(deltaTime>1){
				time+=1;
				deltaTime=0;
				GUI.setData (health, time, prop1, prop2);
				GUI.showUI();

				if(c!=null){
					c.synPosition(gameObject.transform.position);
					c.synRotation(gameObject.transform.rotation);
				}
			}
			if (inAcceleration) {
				deltaAccTime+=Time.deltaTime;
				if(deltaAccTime>10){
					deltaAccTime=0;
					decelerate(0.8f);
				}
			}
			keyInput ();
		}
	}

	void FixedUpdate(){
		if(runnable){
			if (Input.GetAxis ("Vertical")>0) {
				gameObject.rigidbody.AddRelativeForce(0,0,30000);
				if(c!=null)
					c.moveCarForward(carID);
				//networkView.RPC("moveForward",RPCMode.All,carID);
			}
			if (Input.GetAxis ("Vertical")<0) {
				gameObject.rigidbody.AddRelativeForce(0,0,-30000);
				if(c!=null)
					c.moveCarBackward(carID);
				//networkView.RPC("moveBackward",RPCMode.All,carID);
			}
			if (Input.GetAxis ("Horizontal")>0) {
				gameObject.transform.Rotate(0,1,0);
				if(c!=null)
					c.rotateCarRight(carID);
				//networkView.RPC("rotateLeft",RPCMode.All,carID);
			}
			if (Input.GetAxis ("Horizontal")<0) {
				gameObject.transform.Rotate(0,-1,0);
				if(c!=null)
					c.rotateCarLeft(carID);
				//networkView.RPC("rotateRight",RPCMode.All,carID);
			}
		}
	}

	void OnCollisionEnter(Collision collision){}

	void keyInput(){
		if(Input.GetKeyDown(KeyCode.R)) resetPlayer(new Vector3(168,30,172));
		if(Input.GetKeyDown(KeyCode.LeftControl)) fireProps();
	}

	void resetPlayer(Vector3 position){
		gameObject.transform.position = position;
		gameObject.transform.rotation = Quaternion.Euler (0, 0, 0);
		time += 5;//need to decide the value
	}

	void fireProps(){
		if(prop1==-1) return;
		switch(prop1){
		case 0: launchBomb(gameObject.transform.position);break;//bomb
		case 1: accelerate();break;//acceleration
		}
		prop1 = prop2;
		prop2 = -1;
		GUI.setData (health, time, prop1, prop2);
		GUI.showUI ();
	}

	public int getHealth(){
		return health;
	}

	public int getProp(int num){
		if(num==1) return prop1;
		else return prop2;
	}

	public int getFiredPropsType(){
		return firedPropsType;
	}

}
