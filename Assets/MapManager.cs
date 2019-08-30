
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapManager : MonoBehaviour
{
	Color normalColor = Color.white;
	Color mouseDownColor = Color.green;
	Color mouseEnterColor = Color.yellow;

	// Game object which parses and holds data from csv file
	MapData mdm;

	//"ZoneInfo" GO to display text
	private GameObject zi;

	// Zone which is currently selected
	private GameObject zCurr;

	void Start ()
	{
		mdm = GetComponentInChildren<MapData> ();
		zi = GameObject.Find ("ZoneInfo");
		Debug.Log("ZI position: "+zi.transform.position.x 
		+", "+zi.transform.position.y 
		+", "+ zi.transform.position.z);

	}

	public void mapclick (GameObject objClicked)
	{
		Debug.Log ("Map Manager | Clicked: " + objClicked.name);

		if(GameObject.Find ("Canvas").transform.childCount>1){
			int childIndex = 0;
			foreach (Transform child in GameObject.Find ("Canvas").transform) {
				if (childIndex > 0) {
					GameObject.Destroy (child.gameObject);
					Debug.Log ("Destroy:" +childIndex+"\t"+child);
				
				}
				childIndex += 1;
			}		
		}

		MeshRenderer mr = objClicked.GetComponent<MeshRenderer> ();
		mr.material.color = mouseDownColor;
		// zi.GetComponent<Text> ().text = "---";
		
		Dictionary <string, string> record = new Dictionary <string, string> ();
		record = mdm.GetZoneInfo(objClicked.name);
		Debug.Log ("MapManager | record: " + record);


		int idx = 1;
		List <string[]> displayText = new List<string[]>();
		Text t = zi.GetComponent<Text> ();
		foreach(var datum in record){
			Debug.Log ("datum: " + datum.Key);
			//datum is a K/V pair
			if(idx==1){
				t.enabled = true;
				t.text = datum.Key +": "+datum.Value;
			}
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