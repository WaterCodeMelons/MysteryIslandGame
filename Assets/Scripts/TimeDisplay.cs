using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeDisplay : MonoBehaviour {
    public Text timeDisplay;
    public Text dayDisplay;
    private GameObject day;
    private TimeController tc;
    // Use this for initialization
    void Start () {
        day = GameObject.Find("Day");
        tc = day.GetComponent<TimeController>();
	}
	
	// Update is called once per frame
	void Update () {
        timeDisplay.text = tc.hour;
        dayDisplay.text = (tc.day + 1.0f).ToString();
	}
}
