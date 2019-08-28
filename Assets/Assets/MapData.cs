
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
		if(String.IsNullOrEmpty(inputKey)){
			inputKey = "OBJECTID";
			Debug.Log("Using default key of "+inputKey);
		}
		else{			
			Debug.Log("Using key of "+inputKey);
		}

		records = CSVReader.ReadFile(inputFile, inputKey);
		Debug.Log("File "+inputFile +" has records count of "+records.Count);
		
		// foreach(){

		// }

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

	public List <string> GetZoneInfo (string n_)
	{
		List <string> infoList = new List<string>();
		
		int index;
		if (Int32.TryParse (n_, out index)) {
			Debug.Log ("Returning info for Zone " + index);
//			ios = new InfoObject [keyList.Count];
			// for (int i = 0; i < keyList.Count; i += 1) {
			// 	string name = keyList [i]; //i.e. "object_id"
			// 	//Debug.Log (" | " + zoneDict [index] [name]); //get the object_id entry for each row
			// 	//info = String.Concat(info, zoneDict [index-1][name] + "\t");
			// 	infoList.Add(""+zoneDict [index-1][name]);

			// }
			//Debug.Log (" Info List has size: \n" + infoList.Count);
			//Debug.Log (" Zone Info: \n" + info);
			//Debug.Log (" Zone Info Object: " + ios.ObjectID+ "\t : \t"+ios.ZoneOrig);
			infoList.Add("Info Available");
			return infoList;
		} else {
			//Debug.Log ("MapData | Could not find zone info");
			infoList.Add("No Info Available");
			return infoList;
		}
	}
}
