using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MenuControlWithKeys : MonoBehaviour {

    public EventSystem eventSystem;
    public GameObject startingObject;

    private bool activeButton;

	
	// Update is called once per frame
	void Update () {
        if (Input.GetAxisRaw("Vertical") != 0 && activeButton == false)
        {
            eventSystem.SetSelectedGameObject(startingObject);
            activeButton = true;
        }
	}
    private void OnDisable()
    {
        activeButton = false;
    }
}
