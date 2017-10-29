using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
    public float moveSpeed = 30f;
    private Rigidbody rb;
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
        var x = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed; //Pobiera wartości z klawiszy A/D lub Lewo/Prawo
        var z = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed; //Pobiera wartości z klawiszy W/S lub Góra/Dół
        Vector3 movement = new Vector3(x, 0.0f, z);
        rb.transform.Translate(movement);
        //transform.Translate(x, 0, z); //Przesuwa obiekt na płaszczyźnie x (lewo/prawo) i z (przód/tył)
    }
}
