using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapMenuController : MonoBehaviour {

    public Transform MapMenu;
    public Transform Player;
	
	// Update is called once per frame
	void Update ()
    {

        if (MapMenu.gameObject.activeInHierarchy == false)
        {
            if (Input.GetKeyDown(KeyCode.M))
            {
                MapMenu.gameObject.SetActive(true);
            }
        }
        else
        {
            if(Input.GetKeyDown(KeyCode.M))
            {
                MapMenu.gameObject.SetActive(false);
            }
        }

        
		
	}
}
