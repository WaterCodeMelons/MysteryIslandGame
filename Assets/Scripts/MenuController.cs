using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class MenuController : MonoBehaviour {

	public Transform menu;
	public Transform player;
	
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape)) {
			Pause();
		}
	}

	public void Pause () {
		if (menu.gameObject.activeInHierarchy == false) {
			menu.gameObject.SetActive(true);
			Time.timeScale = 0;
			player.GetComponent<FirstPersonController>().enabled = false;
		} else {
			menu.gameObject.SetActive(false);
			Time.timeScale = 1;
			player.GetComponent<FirstPersonController>().enabled = true;
		}
	}

	public void Quit () {
		Application.Quit();
	}
}
