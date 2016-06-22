using UnityEngine;
using System.Collections;

public class CostumGUI : MonoBehaviour {
	public GUIText text;
	public GameObject obj;
	private int health,time,prop1,prop2;
	// Use this for initialization
	void Start () {
		obj = GameObject.Find ("GUI Text");
		text = obj.GetComponent<GUIText> ();
	}
	
	// Update is called once per frame
	void Update () {
	}

	string getPropName(int n){
		if(n==-1) return "None";
		else if(n==0) return "Bomb";
		else if(n==1) return "Acceleration";
		else if(n==2) return "WaterBall";
		else return "Drag";
	}

	public void showUI(){
		string h,t,p1,p2;
		h = "Health:"+health.ToString();
		t = "Time:"+time.ToString();
		p1 = "P1:" + getPropName (prop1);
		p2 = "P2:" + getPropName (prop2);
		
		text.text = h + "  " + t + "  " + p1+" "+p2;
	}

	public void setData(int health,int time,int prop1,int prop2){
		this.health = health;
		this.time = time;
		this.prop1 = prop1;
		this.prop2 = prop2;
	}
}
