
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class MapData : MonoBehaviour
{
	// Name of the input file (no extension) and key to be used to index the zone data, 
	public string inputFile;
	public string inputKey;

	private Dictionary<string, Dictionary<string, string>> records;

	private List<string> keyList;
	// Object which will contain instantiated prefabs in hiearchy
	//public GameObject ZoneHolder;
	

// Use this for initialization
	void Start ()	
	{	
		//Check if the Input Key field in the Unity editor has an entry
		/***@TODO Check if Input Key field is a valid key***/
		if(String.IsNullOrEmpty(inputKey)){
			inputKey = "OBJECTID"; //default key
			Debug.Log("Using default key of "+inputKey);
		}
		else{			
			Debug.Log("Using key of "+inputKey);
		}

		records = CSVReader.ReadFile(inputFile, inputKey);
		Debug.Log("File "+inputFile +" has records count of "+records.Count);
		

		// Declare list of strings, fill with keys (column names)
		//  keyList = new List<string> (zoneDict[indexConst]); //can index any object in the dictionary to get Keys

		// // Print number of keys (using .Count)
		// Debug.Log ("There are " + keyList.Count + " columns in the CSV");
		// foreach (string key in keyList) {
		// 	Debug.Log ("Key is " + key);
		// 	Debug.Log("zoneDict: "+zoneDict[0]["OBJECTID"]);
		// }	
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	public Dictionary <string, string> GetZoneInfo (string key_)
	{
		Debug.Log("Get info for "+key_);
		Dictionary <string, string> record;
		
		if(records.ContainsKey(key_)){
			record = records[key_];
		}
		else{
			record = new Dictionary <string, string>(){ 
				{key_ , "No data found"}
			};
		} 

		return record;
	}
}
