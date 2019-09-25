
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class MapManager : MonoBehaviour
{
	Color normalColor = Color.white;
	Color mouseDownColor = Color.green;
	Color mouseEnterColor = Color.yellow;

	public string inputFile; //Input File field in the Unity Editor
	public string inputKey; //Input Key field in the Unity Editor

	private Dictionary<string, Dictionary<string, string>> records = new Dictionary<string, Dictionary<string, string>>();

	//"ZoneInfo" GameObject use to display text onscreen
	private GameObject zi;

	// Zone which is currently selected
	private GameObject zCurr;

	void Start ()
	{
		// mdm = GetComponentInChildren<MapData> ();
		zi = GameObject.Find ("ZoneInfo");
		// Debug.Log("ZI position: "+zi.transform.position.x 
		// +", "+zi.transform.position.y 
		// +", "+ zi.transform.position.z);

		//Check if the Input Key field in the Unity Editor has an entry
		
		if(String.IsNullOrEmpty(inputKey)){
			inputKey = "OBJECTID"; //default key
			Debug.Log("Using default key of "+inputKey);
		}
		else{			
			Debug.Log("Using key of "+inputKey);
		} 

		//Check that the file input has an entry in the Unity Editor
		if(String.IsNullOrEmpty(inputFile)){
			Debug.LogError("ERROR:  Input file not specified in MapManager in Unity Editor");
			
		}
		else{			
			Debug.Log("Loading file: "+inputFile);
			records = CSVReader.ReadFile(inputFile, inputKey);
			if(records!=null){
				Debug.Log("File "+inputFile +" has records count of "+records.Count);
				/***@TODO: Check if Input Key field is a valid key***/		

			}
			else{
				Debug.LogError("CSVReader ERROR READING " + inputFile);
				Debug.LogError("Exit ");
				ExitGame.Quit();
			}
		}
	}

	public Dictionary<string, string> mapclick (GameObject objClicked)
	{
		// Debug.Log ("Map Manager | Clicked: " + objClicked.name);

		//Remove the previous ZoneInfo objects
		if(GameObject.Find ("Canvas").transform.childCount>1){
			int childIndex = 0;
			foreach (Transform child in GameObject.Find ("Canvas").transform) {
				if (childIndex > 0) {
					GameObject.Destroy (child.gameObject);
					// Debug.Log ("Destroy:" +childIndex+"\t"+child);
				}
				childIndex += 1;
			}		
		}

		MeshRenderer mr = objClicked.GetComponent<MeshRenderer> ();
		mr.material.color = mouseDownColor;

		//Get a Dicitonary holding the data associated with a zone		
		Dictionary <string, string> record = new Dictionary <string, string> ();
		record = GetZoneInfo(objClicked.name);
		// Debug.Log ("MapManager | record: " + record);

		int idx = 1; //just an index used to offset the text onscreen
		Text t = zi.GetComponent<Text> ();
		foreach(var datum in record){ //datum is a K/V pair
			// Debug.Log ("datum: " + datum.Key);
			//Replace the origial placeholder text element with the first datum in the record (e.g. OBJECTID)
			if(idx==1){
				t.enabled = true;
				t.text = datum.Key +": "+datum.Value;
			}
			//Create additional text elements for the rest of the data
			else{
				GameObject tClone = Instantiate (zi);//, new Vector3(300, -00+(idx * 75), 0), Quaternion.identity);
				tClone.transform.SetParent(zi.transform.parent);
				// Debug.Log("x: "+zi.transform.parent.position.x);
				tClone.transform.position = new Vector3 (zi.transform.position.x, zi.transform.position.y-(50*idx), zi.transform.position.z);
				tClone.GetComponent<Text>().text = datum.Key +": "+datum.Value;
			}
			idx += 1;
		}	
			
		if (zCurr) {
			mr = zCurr.GetComponent<MeshRenderer> ();
			mr.material.color = normalColor;
		}
		zCurr = objClicked;
		
		return record;

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

	public static class ExitGame
	{
		#if UNITY_WEBPLAYER
		public static string webplayerQuitURL = "http://google.com";
		#endif
		public static void Quit()
		{
			#if UNITY_EDITOR
			UnityEditor.EditorApplication.isPlaying = false;
			#elif UNITY_WEBPLAYER
			Application.OpenURL(webplayerQuitURL);
			#else
			Application.Quit();
			#endif
		}
	}

	public void mapMouseDown (GameObject objClicked)
	{
		//Debug.Log ("Pointer Down: " + objClicked.name);

	}
	//
	public void mapMouseUp (GameObject objClicked)
	{
		//Debug.Log ("Pointer Up: " + objClicked.name);

//		MeshRenderer mr = objClicked.GetComponent<MeshRenderer> ();
//		mr.material.color = normalColor;
//		;
	}

	public void mapMouseEnter (GameObject objClicked)
	{
		//Debug.Log ("Pointer Enter: " + objClicked.name);

		MeshRenderer mr = objClicked.GetComponent<MeshRenderer> ();
		mr.material.color = mouseEnterColor;
	}

	public void mapMouseExit (GameObject objClicked)
	{
		//Debug.Log ("Pointer Exit: " + objClicked.name);
		if (objClicked != zCurr) {
			MeshRenderer mr = objClicked.GetComponent<MeshRenderer> ();
			mr.material.color = normalColor;
		}
	}
}