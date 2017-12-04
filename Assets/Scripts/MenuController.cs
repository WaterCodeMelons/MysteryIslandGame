using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{

    public Transform menu;
    public Transform player;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        { // Jeżeli podczas gry klikniemy Escape to przechodzi do metody Pause()
            Pause();
        }

    }

    public void Pause()
    {
        if (menu.gameObject.activeInHierarchy == false)
        { // Jeżeli menu nie jest aktywne w hierarchii
            menu.gameObject.SetActive(true); // Ustaw menu jako aktywny element
            Time.timeScale = 0; // Zatrzymaj czas
            Cursor.visible = true;
            player.GetComponent<FirstPersonController>().enabled = false; // Wyłącz działanie FPC
        }
        else
        {
            menu.gameObject.SetActive(false); // Ustaw menu jako nieaktywny element
            Time.timeScale = 1; // Włącz czas
            Cursor.visible = false;
            player.GetComponent<FirstPersonController>().enabled = true; // Pozwól na działanie FPC
        }
    }

    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
		Application.Quit(); // Wyjdź z gry
#endif
    }
}
