﻿using UnityEngine;
using UnityEngine.EventSystems;

public class MapClickDetector : MonoBehaviour, IPointerClickHandler, 
IPointerDownHandler, IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler
{
    MapManager mapManager;

    void Start()
    {
        addPhysicsRaycaster();
        mapManager = GameObject.Find("MapManager").GetComponent<MapManager>();
	
    }

    void addPhysicsRaycaster()
    {
        PhysicsRaycaster physicsRaycaster = GameObject.FindObjectOfType<PhysicsRaycaster>();
        if (physicsRaycaster == null)
        {
            Camera.main.gameObject.AddComponent<PhysicsRaycaster>();
        }
    }

    public void OnPointerClick(PointerEventData eventData)

    {
		//Debug.Log ("Pointer Click: ");
        mapManager.mapclick(gameObject); //mapclick returns the record for the zone so the UI could access the text from here or in MapManager
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        mapManager.mapMouseDown(gameObject);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        mapManager.mapMouseUp(gameObject);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        mapManager.mapMouseEnter(gameObject);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        mapManager.mapMouseExit(gameObject);
    }
}
