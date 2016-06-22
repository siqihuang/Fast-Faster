using UnityEngine;
using System.Collections;

/*
 * generate 4 kinds of events
 */ 

public class eventController : MonoBehaviour {
	public mountainEvent mountain;
	public volcanoEvent volcano;
	public spikeEvent spike;
	public thunderEvent thunder;

	eventController(){}

	/*
	 * responsible for generating events
	 */ 
	public void generateEvent(){}
}
