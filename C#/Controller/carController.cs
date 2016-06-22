using UnityEngine;
using System.Collections;

/*
 * this script is reponsible for storing the basic infomation of a car, no matter a player car, internet car or computer car
 */ 

public class carController : MonoBehaviour{
	protected Vector3 position,velocity;
	protected Quaternion rotation;
	protected int carID,prop1,prop2,time,win;
	protected float deltaTime,deltaAccTime;
	public GameObject leftParticle,rightParticle,bomb,waterBall;
	public Renderer leftParticleRender,rightParticleRender;
	public bool inAcceleration,runnable;
	// Use this for initialization

	protected void Start(){
		inAcceleration = false;
		deltaAccTime = 0;
		leftParticleRender = leftParticle.GetComponent<Renderer> ();
		rightParticleRender = rightParticle.GetComponent<Renderer> ();
		leftParticleRender.enabled = false;
		rightParticleRender.enabled = false;
	}

	public void setCarID(int carID){
		this.carID = carID;
	}

	public void moveForwardCar(){
		gameObject.rigidbody.AddRelativeForce (0, 0, 30000);
	}
	
	public void moveBackwardCar(){
		gameObject.rigidbody.AddRelativeForce (0, 0, -30000);
	}
	
	public void rotateLeft(){
		gameObject.transform.Rotate(0,-1,0);
	}
	
	public void rotateRight(){
		gameObject.transform.Rotate(0,1,0);
	}
	
	public void fireProps(int carID){
	}

	public void launchBomb(Vector3 startPos){
		GameObject obj=Instantiate(bomb,startPos,Quaternion.identity) as GameObject;
		bomb b = obj.GetComponent<bomb> ();
	}

	public void accelerate(){
		gameObject.rigidbody.drag = 0;
		inAcceleration = true;
		leftParticleRender.enabled = true;
		rightParticleRender.enabled = true;
	}

	public void decelerate(float drag){
		gameObject.rigidbody.drag = drag;
		inAcceleration = false;
		leftParticleRender.enabled = false;
		rightParticleRender.enabled = false;
	}

	void OnTriggerEnter(Collider other){
		if(other.tag == "propbox"){
			//other.gameObject.audio.Play();
			Destroy(other.gameObject);
			int ran=Random.Range(0,2);
			prop2=prop1;prop1=ran;
		}
	}

	/*
	 * used to reset car information for internet car
	 */ 
	
}


