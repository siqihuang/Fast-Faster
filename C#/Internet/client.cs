using UnityEngine;
using System.Collections;
using System.Threading;

public class client : MonoBehaviour {
	private int playerID,playerNum;
	private gameController gameInfo;

	// Use this for initialization
	void Start () {
		playerID = -1;
		DontDestroyOnLoad (this);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI () 
	{
		//网络连接状态
		switch(Network.peerType)
		{
			//服务器未开启状态
		case NetworkPeerType.Disconnected:
			//StartConnect();
			break;
			//成功连接运行于服务端
		case NetworkPeerType.Server:
			
			break;
			//成功连接运行于客户端
		case NetworkPeerType.Client:
			//OnClient();
			break;
			//正在尝试连接中
		case NetworkPeerType.Connecting:
			
			break;
		}
		
	}
	
	public void connectToLocalHost(int port){
		string localhost = "127.0.0.1";
		NetworkConnectionError error = Network.Connect(localhost, port);
		Debug.Log("client connecting："+error);
	}

	public void connectToHost(string IP,int port){
		NetworkConnectionError error = Network.Connect(IP, port);
		Debug.Log("connecting："+error);
	}

	public void moveCarForward(int carID){
		networkView.RPC("moveForward",RPCMode.All,carID);
		Debug.Log ("###");
	}

	public void moveCarBackward(int carID){
		networkView.RPC("moveBackward",RPCMode.All,carID);
	}

	public void rotateCarLeft(int carID){
		networkView.RPC("rotateLeft",RPCMode.All,carID);
	}

	public void rotateCarRight(int carID){
		networkView.RPC("rotateRight",RPCMode.All,carID);
	}

	public void sendCarReady(){
		networkView.RPC ("sendReady", RPCMode.All);
	}

	public void synPosition(Vector3 pos){
		networkView.RPC ("synPos", RPCMode.All, playerID, pos);
	}

	public void synRotation(Quaternion rot){
		networkView.RPC ("synRot", RPCMode.All, playerID, rot);
	}

	[RPC]
	void synPos(int ID,Vector3 pos,NetworkMessageInfo info){
		Debug.Log (ID);
		gameInfo.setPosition(ID,pos);
	}

	[RPC]
	void synRot(int ID,Quaternion rot,NetworkMessageInfo info){
		gameInfo.setRotation(ID,rot);
	}

	[RPC]
	void startRunning(NetworkMessageInfo info){
		gameInfo.setRunnable ();
	}

	[RPC]
	void sendReady(NetworkMessageInfo info){
	}

	[RPC]
	void setID(int ID, NetworkMessageInfo info)
	{
		if(playerID==-1) playerID=ID;
	}

	[RPC]
	void moveForward(int ID, NetworkMessageInfo info)
	{
		if(ID!=playerID)
			gameInfo.moveForwardCar (ID);
	}

	[RPC]
	void moveBackward(int ID, NetworkMessageInfo info)
	{
		if(ID!=playerID)
			gameInfo.moveBackwardCar (ID);
	}

	[RPC]
	void rotateLeft(int ID, NetworkMessageInfo info)
	{
		if(ID!=playerID)
			gameInfo.rotateLeft (ID);
	}

	[RPC]
	void rotateRight(int ID, NetworkMessageInfo info)
	{
		if(ID!=playerID)
			gameInfo.rotateRight (ID);
	}

	[RPC]
	void fireProps(int ID, NetworkMessageInfo info)
	{
		//
	}

	[RPC]
	void startGame(int playerNum,NetworkMessageInfo info){
		this.playerNum = playerNum;
		Application.LoadLevel ("mainScene");
		Thread.Sleep (5000);
	}

	public void setGameInfo(gameController gameInfo){
		this.gameInfo = gameInfo;
	}

	public int getPlayerNum(){
		return playerNum;
	}

	public int getPlayerID(){
		return playerID;
	}
}
