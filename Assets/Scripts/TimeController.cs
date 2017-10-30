using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeController : MonoBehaviour {

	// Informacje o czasie
	[Header("Time")]
	public float time = 0.5f;
	public float day;
	public string hour;
	
	[Space]

	[Header("Settings")]
	// Światło kierunkowe sceny
	[SerializeField] private Light sun;
	// Obiekt słońca i księżyca
	[SerializeField] private GameObject plaskaOrbita;
	// Zmienna sterująca czasem gry ile minut irl to 24h w grze
	[SerializeField] private float minutesInAFullDay = 10f;

	// Aktualny czas dnia pobierany z czasu globalnego
	private float currentTimeOfDay;
	private float sunInitialIntenisty;

	void Start () {
		// Podczas startu gry skrypt przyjmuje intensywność oświetlenia z światła kierunkowego
		sunInitialIntenisty = sun.intensity;
	}

	void Update () {
		updateSun();
		// 
		time += (Time.deltaTime / (minutesInAFullDay * 60));
		day = (int)time;
		hour = (int)(currentTimeOfDay*24)+":"+(int)((currentTimeOfDay*24*60) - ((int)(currentTimeOfDay*24)*60));
		currentTimeOfDay = time - (int)time;
		if (currentTimeOfDay >= 1) {
			currentTimeOfDay = 0;
		}
	}

	void updateSun () {
		// Obrót światła kierunkowego wokół właśnej osi
		sun.transform.localRotation = Quaternion.Euler((currentTimeOfDay * 360f) - 90, 170, 0);
		// Obrót pustego obiektu ze słońcem i księżycem wokół własnej osi
		plaskaOrbita.transform.localRotation = Quaternion.Euler (0, 170, (currentTimeOfDay * 360f) - 90);

		float intensityMultiplier = 1;

		/*
		 * Czas dnia przechodzi od 0 do 1 [0 - 1]
		 * Jeśli czas dnia [0 - 0.23] lub [0.73 - 0.80] : intensityMultiplier = 0 - kompletna noc
		 * Jeśli czas dnia wynosi [0.30 - 0.80] jest dzień : intensityMultiplier = 1 - kompletny dzień
		 * Wschód trwa od 0.23 do 0.30 - intensityMultiplier rośnie w zależności od czasu
		 * Zachód trwa od 0.73 do 0.80 - intenistyMultiplier maleje w zależności od czasu
		 * Metoda Mathf.Clamp01() utrzymuje podaną wartość pomiędzy [0 - 1]
		 *                                                          Mathf.Clamp01(-1) = 0;
		 *                                                          Mathf.Clamp01(5) = 1;
		 *                                                          Mathf.Clamp01(0.5f) = 0.5f;
		 */
		if (currentTimeOfDay <= 0.23f || currentTimeOfDay >= 0.80f) {
			intensityMultiplier = 0.0f;
		} else if (currentTimeOfDay <= 0.30f) {
			intensityMultiplier = Mathf.Clamp01((currentTimeOfDay - 0.23f) * (1 / 0.07f));
		} else if (currentTimeOfDay >= 0.73f) {
			intensityMultiplier = Mathf.Clamp01(1 - ((currentTimeOfDay - 0.73f) * (1 / 0.07f)));
		}

		// Podstawowy poziom intensywności oświetlenia kierunkowego sceny zostaje pomnożony przez mnożnik tego oświetlenia
		sun.intensity = sunInitialIntenisty * intensityMultiplier;

		// Podstawowy kolor mgły RGBA(128, 128, 128, 255) : Color(0.5f, 0.5f, 0.5f, 1f) zostaje pomnożony przez mnożnik intensywności dnia
		// Noc - kolor czarny rgba(0, 0, 0, 1)
		// Podczas wschodu kolor zmienia się z czarnego rgba(0, 0, 0, 1) na szary rgba(128, 128, 128, 255)
		// Podczas zachodu kolor zmienia się z szarego rgba(128, 128, 128, 255) na czarny rgba(0, 0, 0, 255)
		RenderSettings.fogColor = new Color(0.5f*intensityMultiplier, 0.5f*intensityMultiplier, 0.5f*intensityMultiplier, 1f);

		// Zmienia ekspozycję skyboxa i blokuje ją pomiędzy [0.25 - 0.8]
		RenderSettings.skybox.SetFloat("_Exposure", Mathf.Clamp(0.8f * intensityMultiplier, 0.025f, 0.8f));

		// Zabarwienie skyboxa zostaje zmienione podczas wschodu i zachodu pomiędzy rgba(128, 128, 128, 255) a rgba(128, 128, 255)
		RenderSettings.skybox.SetColor("_Tint", new Color(0.5f, 0.5f, 1 - 0.5f * intensityMultiplier, 1));
	}
}
