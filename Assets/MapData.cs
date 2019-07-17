
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapData : MonoBehaviour
{
	// Name of the input file, no extension
	public string inputFile;

	// List for holding data from CSV reader
	private List<Dictionary<string, object>> zoneList;
	// The names of cols
	private List<string> keyList;
	// Object which will contain instantiated prefabs in hiearchy
	//public GameObject ZoneHolder;


// Use this for initialization
	void Start ()
	{
		// Set list to results of function Reader with argument inputfile
		zoneList = CSVReader.Read(inputFile);
		Debug.Log("ZoneList has count: "+zoneList.Count);
		// String val;
		
		Int32 indexConst = 0;
		// Declare list of strings, fill with keys (column names)
		keyList = new List<string> (zoneList[indexConst].Keys); //can index any object in the dictionary to get Keys

		// Print number of keys (using .count)
		Debug.Log ("There are " + keyList.Count + " columns in the CSV");
		foreach (string key in keyList) {
			Debug.Log ("Key is " + key);
			Debug.Log("ZoneList: "+zoneList[0]["OBJECTID"]);
		}	
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	public List <string> GetZoneInfo (string n_)
	{
		//String info = "";
		//ZoneInfoObject ios = new ZoneInfoObject ("", "");
		List <string> infoList = new List<string>();
		
		int index;
		if (Int32.TryParse (n_, out index)) {
			Debug.Log ("Returning info for Zone index" + index);
//			ios = new InfoObject [keyList.Count];
			// for (int i = 0; i < keyList.Count; i += 1) {
			// 	string name = keyList [i]; //i.e. "object_id"
			// 	//Debug.Log (" | " + zoneList [index] [name]); //get the object_id entry for each row
			// 	//info = String.Concat(info, zoneList [index-1][name] + "\t");
			// 	infoList.Add(""+zoneList [index-1][name]);

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
