
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
	private List<string> columnList;
	// Object which will contain instantiated prefabs in hiearchy
	//public GameObject ZoneHolder;


// Use this for initialization
	void Start ()
	{
		// Set list to results of function Reader with argument inputfile
		zoneList = CSVReader.Read (inputFile);

		// Declare list of strings, fill with keys (column names)
		columnList = new List<string> (zoneList[1].Keys);

		// Print number of keys (using .count)
//		Debug.Log ("There are " + columnList.Count + " columns in the CSV");
//		foreach (string key in columnList) {
//			Debug.Log ("Column name is " + key);
//		}	
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
		//If data is contiguous and ascending...
		int index;
		if (Int32.TryParse (n_, out index)) {
//			Debug.Log ("Returning info for Zone index" + index);
//			ios = new InfoObject [columnList.Count];
			for (int i = 0; i < columnList.Count; i += 1) {
				string name = columnList [i]; //i.e. "object_id"
				//Debug.Log (" | " + zoneList [index] [name]); //get the object_id entry for each row
				//info = String.Concat(info, zoneList [index-1][name] + "\t");
				infoList.Add(""+zoneList [index-1][name]);

			}
			//Debug.Log (" Info List has size: \n" + infoList.Count);
			//Debug.Log (" Zone Info: \n" + info);
			//Debug.Log (" Zone Info Object: " + ios.ObjectID+ "\t : \t"+ios.ZoneOrig);
			return infoList;
		} else {
			//Debug.Log ("MapData | Could not find zone info");
			infoList.Add("No Info Available");
			return infoList;
		}
	}
}
