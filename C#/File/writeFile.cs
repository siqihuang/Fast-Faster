using UnityEngine;
using System.Collections;
using System.IO;

/*
 * need to write data to specify file
 * need to specify the data structure
 */ 
public class writeFile{
	private writeFile writer;
	private string fileName;
	//public outputData
	//the above data structure is public, all writing info is set to it instead of redefining by other classes
	writeFile(){}

	writeFile(string fileName){
		this.fileName = fileName;
		//TODO
		/*
		 * need to open the file for writing
		 */ 
	}

	public void setFileName(string fileName){
		this.fileName = fileName;
	}

	public string getFileName(){
		return fileName;
	}

	/*
	 * the inner value is not void, when data structure is decided, change it to the data
	 * return true if successful, false if not
	 */ 
	public bool writeHighScoreData(){
		//TODO
		//writer.write(data)
		return true;
	}

	/*
	 * the inner value is not void, when data structure is decided, change it to the data
	 * return true if successful, false if not
	 */ 
	public bool writeResourceData(){
		//TODO
		return true;
	}

	/*
	 * the inner value is not void, when data structure is decided, change it to the data
	 * return true if successful, false if not
	 */ 
	public bool writePropsData(){
		return true;
	}
}
