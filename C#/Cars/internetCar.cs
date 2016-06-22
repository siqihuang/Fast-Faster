using UnityEngine;
using System.Collections;

/*
 * the script is responsible for showing cars on the internet
 */ 

public class internetCar : carController {

	// Use this for initialization
	new void Start () {
		base.Start ();
		deltaTime = 0;
	}
	
	// Update is called once per frame
	void Update () {
		deltaTime += Time.deltaTime;
		if (inAcceleration) {
			deltaAccTime+=Time.deltaTime;
			if(deltaAccTime>10){
				deltaAccTime=0;
				decelerate(0.8f);
			}
		}
	}

	void OnCollisionEnter(Collision collision){}
}
