using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeController : MonoBehaviour {

	[Header("Time")]
	[SerializeField] public float time = 0.5f;
	[SerializeField] public float day;
	[SerializeField] public string hour;
	
	[Space]

	[Header("Settings")]
	[SerializeField] private Light sun;
	[SerializeField] private GameObject plaskaOrbita;
	[SerializeField] private float minutesInAFullDay = 0.5f;

	private float currentTimeOfDay;
	private float timeMultiplier = 1f;
	private float sunInitialIntenisty;

	void Start () {
		sunInitialIntenisty = sun.intensity;
	}

	void Update () {
		updateSun();
		time += (Time.deltaTime / (minutesInAFullDay * 60)) * timeMultiplier;
		day = (int)time;
		hour = (int)(currentTimeOfDay*24)+":"+(int)((currentTimeOfDay*24*60) - ((int)(currentTimeOfDay*24)*60));
		currentTimeOfDay = time - (int)time;
		if (currentTimeOfDay >= 1) {
			currentTimeOfDay = 0;
		}
	}

	void updateSun () {
		sun.transform.localRotation = Quaternion.Euler ((currentTimeOfDay * 360f) - 90, 170, 0);
		plaskaOrbita.transform.localRotation = Quaternion.Euler (0, 170, (currentTimeOfDay * 360f) - 90);

		float intensityMultiplier = 1;

		if (currentTimeOfDay <= 0.23f || currentTimeOfDay >= 0.80f) {
			intensityMultiplier = 0.0f;
		} else if (currentTimeOfDay <= 0.30f) {
			intensityMultiplier = Mathf.Clamp01((currentTimeOfDay - 0.23f) * (1 / 0.07f));
		} else if (currentTimeOfDay >= 0.73f) {
			intensityMultiplier = Mathf.Clamp01(1 - ((currentTimeOfDay - 0.73f) * (1 / 0.07f)));
		}

		sun.intensity = sunInitialIntenisty * intensityMultiplier;

		RenderSettings.fogColor = new Color(0.2f*intensityMultiplier, 0.2f*intensityMultiplier, 0.2f*intensityMultiplier, 1f);
		RenderSettings.skybox.SetFloat("_Exposure", Mathf.Clamp(0.8f * intensityMultiplier, 0.025f, 0.8f));
		RenderSettings.skybox.SetColor("_Tint", new Color(0.5f, 0.5f, 1 - 0.5f * intensityMultiplier, 1));
	}
}
