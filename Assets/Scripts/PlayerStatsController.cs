using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatsController : MonoBehaviour {

	[Header("Base stats value")] // Maksymalne wartości statystyk pokazane w inspektorze
	public int maxHealth = 100;
	public int maxHunger = 100;
	public int maxThirst = 100;

	[Space]

	[Header("Base stats decay")] // Spadek życia w ciągu dnia/sekundy
	public float healthDecayPerSecond = 1;
	public float hungerDecayPerDay = 50;
	public float thirstDecayPerDay = 200;

	[Space]

	[Header("Stat bars")] // Paski statystyk
	public GameObject healthBar;
	public GameObject hungerBar;
	public GameObject thirstBar;

	private float health;
	private float hunger;
	private float thirst;


	void Start () { // Przypisuje statystykom maksymalne wartości, podane powyżej
		health = maxHealth; 
		hunger = maxHunger;
		thirst = maxThirst;
	}
	
	void Update () {
        updateStats(); // Wywołuje metodę updateStats() w ciągu każdej sekundy
		if (hunger > 0) { // Jeżeli wartość głodu jest >0 zmniejsz wartość głodu o czas rzeczywyisty podzielony przez wartość hungerDecayPerDay * godzina w grze 
			hunger -= Time.deltaTime / (TimeController.minutesInAFullDayDisplay * 60) * hungerDecayPerDay;
		}

		if (thirst > 0) { // Dokładnie tak samo jak hunger
			thirst -= Time.deltaTime / (TimeController.minutesInAFullDayDisplay * 60) * thirstDecayPerDay;
		}

		if (hunger <= 0 && thirst <= 0 && health > 0) { // Jeżeli wartość głodu i pragnienia jest < 0, a wartość HP jest > 0 to hp--
			health -= Time.deltaTime * healthDecayPerSecond;
		}
	}

	void updateStats () { // Skracanie pasków statystyk
		healthBar.transform.localScale = new Vector3(health/maxHealth, 1, 1); 
		hungerBar.transform.localScale = new Vector3(hunger/maxHunger, 1, 1);
		thirstBar.transform.localScale = new Vector3(thirst/maxThirst, 1, 1);
	}
}
