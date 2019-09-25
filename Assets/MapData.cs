
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class MapData : MonoBehaviour
{
	// Name of the input file (no extension) and key to be used to index the zone data, 
	

	

	private List<string> keyList;
	// Object which will contain instantiated prefabs in hiearchy
	//public GameObject ZoneHolder;
	

// Use this for initialization
	void Start ()	
	{	
		
		

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

}	