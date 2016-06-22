using UnityEngine;
using System.Collections;

/*
 * attached to the bomb prefab
 * the bomb find the way and hit the target
 */ 
public class bomb : MonoBehaviour {
	private Vector3 target;
	private float deltaFetchTime,minFetchTime,rotationSpeed;
	private Quaternion orientation;
	public GameObject fire;

	// Use this for initialization
	void Start () {
		target = new Vector3 (970, 435, 1272);//to be dicided
		minFetchTime = 0.5f;
		deltaFetchTime = 0;
		rotationSpeed = 5f;
	}
	
	// Update is called once per frame
	void Update () {
		deltaFetchTime += Time.deltaTime;
	}

	void FixedUpdate(){
		Vector3 pos=gameObject.transform.position;
		if(deltaFetchTime>minFetchTime){
			deltaFetchTime=0;
			Vector3 dir=target-pos;
			dir.Normalize();
			orientation=Quaternion.LookRotation(dir);
			gameObject.rigidbody.velocity = new Vector3 (0, 0, 0);
			gameObject.rigidbody.AddRelativeForce (0, 0, 3000);
		}
		transform.rotation = Quaternion.Slerp(gameObject.transform.rotation, orientation, Time.deltaTime * rotationSpeed);
		//pos.z += 10 * Time.deltaTime;
	}
	
	void OnCollisionEnter(Collision collision){
		Die ();
	}
	
	void Die(){
		GameObject obj = Instantiate (fire, this.transform.position, Quaternion.identity) as GameObject;
		Destroy (gameObject);
	}

	public void setTarget(Vector3 target){
		this.target = target;
	}

	public Vector3 getTarget(){
		return target;
	}
}
