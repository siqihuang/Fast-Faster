using UnityEngine;
using System.Collections;
using System.IO;

public class readFile : MonoBehaviour {
	private StreamReader reader;
	private string fileName;
	private int fileType;
	public int HIGHSCORE=0,RESOURCE=1,PROPS=2;
	//three types here, different reading block
	//define your own data block here

	readFile(){}
	readFile(string fileName,int fileType){
		this.fileName = fileName;
		this.fileType = fileType;
		//TODO
		//write initiate Function to open the file
	}

	/*
	 * the function get the data from the file and store it in the data block
	 */ 
	public void readData(){
		//TODO
	}

	/*
	 * close the file, return true if successful, false otherwise
	 */ 
	public bool closeFile(){
		reader.Close ();
		return true;
	}

	/*
	 * the return value is not void, change it when data structure is decided
	 */
	public void getData(){
		//TODO
	}

	public void setFileName(string fileName){
		this.fileName = fileName;
	}
	
	public string getFileName(){
		return fileName;
	}
}
