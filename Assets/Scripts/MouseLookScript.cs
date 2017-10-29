using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLookScript : MonoBehaviour {
    public float mouseSensitivity = 100f; //Czułość myszki
    public float clampAngle = 30f; //Limiter wartości kątów
    public Rigidbody rb; //Tworzę odwołanie do Rigidbody aby móc operować na nim
    private float rotX = 0.0f; // Rotacja góra/dół
    private float rotY = 0.0f; // Rotacja lewo/prawo
    private float mouseX, mouseY;  //Tworzę zmienne aby pobierać wartości z myszki
    void Start()
    {
        Vector3 rot = transform.localRotation.eulerAngles; //Tworzę wektor3 (x/y/z) aby przedstawić obecne wartości rotacyjne obiektu
        rotX = rot.x; //Przypisuje rotacji Lewo/Prawo wartość x powyższego wektora
        rotY = rot.y; //Przypisuje rotacji Góra/Dół wartość y powyższego wektora
    }

    void Update()
    {
        mouseX = Input.GetAxis("Mouse X"); //Pobieram wartości Lewo/Prawo z myszki
        mouseY = -Input.GetAxis("Mouse Y"); //Pobieram wartości Góra/Dół z myszki ALE! na odwrót, dlatego minus
        rotY += mouseX * mouseSensitivity * Time.deltaTime; //Nakładam na Rotację lewo/prawo czułość myszki (zdefiniowaną wyżej)
        rotX += mouseY * mouseSensitivity * Time.deltaTime; //Nakładam na Rotację góra/dół czułość myszki (zdefiniowaną wyżej)
        rotX = Mathf.Clamp(rotX, -clampAngle, clampAngle); //Nakładam limit na możliwość obrotu góra/dół
        transform.rotation = Quaternion.Euler(rotX, rotY, 0.0f); //obracam kamerę na podstawie obrotu myszki 
        rb.rotation = Quaternion.Euler(new Vector3(0f, rotY, 0f)); //obracam kapsułę na podstawie obrotu myszki
        Debug.Log(rb.rotation); //Debuguje aby przedstawić w konsoli rotację myszki
    }
}
