using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeDisplay : MonoBehaviour {
    public Text timeDisplay;
    public Text dayDisplay;

     void Update () {
        
        // Because TimeController class has a public static field "time, hour, day" You can access it directly
        timeDisplay.text = TimeController.hourDisplay;
        dayDisplay.text = (TimeController.dayDisplay + 1).ToString();
    }
}
