using UnityEngine;
using System.Collections;

public class propbox : MonoBehaviour {
	private Vector3 position;
	private Quaternion rotation;
	private int type;

	propbox(int type){
		this.type = type;
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (new Vector3 (15, 30, 45) * Time.deltaTime);
	}

	public int getType(){
		return type;
	}
}
