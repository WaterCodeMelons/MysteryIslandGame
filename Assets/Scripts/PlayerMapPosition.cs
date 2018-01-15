using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMapPosition : MonoBehaviour {

    public Transform Player;
    public Transform PlayerOnMapPosition;

	// Update is called once per frame
	void Update ()
    {
        PlayerOnMapPosition.transform.position = new Vector3(Player.position.x, 501f, Player.position.z);
	}
}
