using UnityEngine;
using System.Collections;
using System.Threading;

public class server : MonoBehaviour {
	public int mode,readyPlayer=0;
	public static int SELECTED=0,CREATED=1,INGAME=2;
	private string stringPort,message="";
	private int port,playerNum;
	private multiModeUI m;
	private client c;
	Vector2 scrollPosition;

	// Use this for initialization
	void Start () {
		stringPort = "9090";
		port = 9090;
		mode = SELECTED;
		playerNum = 0;
		GameObject obj = GameObject.Find ("client");
		c = obj.GetComponent<client> ();
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnGUI(){
		if(mode==SELECTED){
			createGame ();
		}
		else if(mode==CREATED){
			connecting();
		}
		else{
			InGame();
		}
	}

	void InGame()
	{
		GUILayout.Label("服务器创建完毕，等待客户端连接");
		//得到客户端连接的数量
		/*int length = Network.connections.Length;
		for(int i =0; i<length; i++)
		{
			GUILayout.Label("连接服务器客户端ID" + i);
			GUILayout.Label("连接服务器客户端IP" + Network.connections[i].ipAddress);
			GUILayout.Label("连接服务器客户端端口号" + Network.connections[i].port);
		}
		//断开服务器
		if (GUILayout.Button("断开服务器"))
		{
			Network.Disconnect();
			//重置聊天信息
			Message="";
			MoveInfo="";
		}
		//创建一个滚动视图，用来显示聊天的信息
		*/

		scrollPosition = GUILayout.BeginScrollView(scrollPosition, GUILayout.Width(200), GUILayout.Height(Screen.height));

		//显示聊天信息
		//GUILayout.Box("!");
		//显示玩家移动信息
		GUILayout.Box(message);
		GUILayout.EndScrollView();

		
	}
	
	void createGame(){
		GUILayout.BeginArea(new Rect(10,Screen.height/2+50,Screen.width-20,200));
		GUILayout.Label ("Port");
		stringPort=GUILayout.TextField (stringPort);
		if (GUILayout.Button ("OK")) {
			mode=CREATED;
			port=int.Parse(stringPort);
			NetworkConnectionError error = Network.InitializeServer(10, port, false);
			Debug.Log("server connecting："+error);
			//c.connectToLocalHost(port);
		}
		if (GUILayout.Button ("Cancel")) {
			Application.LoadLevel("multiModeScene");
		}
		GUILayout.EndArea ();
	}

	void connecting(){
		GUILayout.BeginArea(new Rect(10,Screen.height/2+100,Screen.width-20,200));
		playerNum = Network.connections.Length;
		networkView.RPC ("setID", RPCMode.Others, playerNum - 1);
		//Thread.Sleep (1000);
		GUILayout.Label ("number of players:" + playerNum.ToString ());
		if(GUILayout.Button("OK")){
			networkView.RPC("startGame",RPCMode.All,playerNum);
			//mode=INGAME;
		}
		GUILayout.EndArea ();
	}

	[RPC]
	void synPos(int ID,Vector3 pos,NetworkMessageInfo info){
	}
	
	[RPC]
	void synRot(int ID,Quaternion rot,NetworkMessageInfo info){
	}

	[RPC]
	void startRunning(NetworkMessageInfo info){

	}

	[RPC]
	void sendReady(NetworkMessageInfo info){
		readyPlayer++;
		if(readyPlayer==playerNum)
			networkView.RPC("startRunning",RPCMode.All);
	}

	[RPC]
	void startGame(int playerNum,NetworkMessageInfo info){
	}

	[RPC]
	void setID(int ID, NetworkMessageInfo info)
	{
		message += "set ID\n";
	}

	[RPC]
	void moveForward(int ID, NetworkMessageInfo info)
	{
		message += "forward\n";
	}
	
	[RPC]
	void moveBackward(int ID, NetworkMessageInfo info)
	{
		message += "backward";
	}
	
	[RPC]
	void rotateLeft(int ID, NetworkMessageInfo info)
	{
		message += "turn left\n";
	}
	
	[RPC]
	void rotateRight(int ID, NetworkMessageInfo info)
	{
		message += "turn right\n";
	}
	
	[RPC]
	void fireProps(int ID, NetworkMessageInfo info)
	{
		//
	}
}
