using UnityEngine;
using System.Collections;

public class clientGUI : MonoBehaviour {
	private int playerID;
	private string IPAddress,stringPort;
	private int port,mode;
	public static int NOTCONNECTED=0,CONNECTED=1;
	private client c;

	// Use this for initialization
	void Start () {
		IPAddress = "127.0.0.1";
		stringPort = "9090";
		port = 9090;
		mode = NOTCONNECTED;
		GameObject obj = GameObject.Find ("client");
		c = obj.GetComponent<client> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnGUI(){
		if(mode==NOTCONNECTED){
			connecting();
		}
		else{
			connected();
		}
	}
	
	void connecting(){
		GUILayout.BeginArea(new Rect(10,Screen.height/2,Screen.width-20,200));
		GUILayout.Label ("IP Address");
		IPAddress = GUILayout.TextField (IPAddress);
		GUILayout.Label ("Port");
		stringPort = GUILayout.TextField (stringPort);
		if (GUILayout.Button ("OK")) {
			port=int.Parse(stringPort);
			c.connectToHost(IPAddress,port);
			mode=CONNECTED;
		}
		if (GUILayout.Button ("Cancel")) {
			Application.LoadLevel("multiModeScene");
		}
		GUILayout.EndArea ();
	}
	
	void connected(){
		GUILayout.BeginArea(new Rect(10,Screen.height/2+100,Screen.width-20,200));
		GUILayout.Label("playerID:"+c.getPlayerID());
		GUILayout.EndArea ();
	}
}
