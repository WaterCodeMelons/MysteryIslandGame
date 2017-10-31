using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatsController : MonoBehaviour {

	[Header("Base stats value")]
	public int maxHealth = 100;
	public int maxHunger = 100;
	public int maxThirst = 100;

	[Space]

	[Header("Base stats decay")]
	public float healthDecayPerSecond = 1;
	public float hungerDecayPerDay = 50;
	public float thirstDecayPerDay = 200;

	[Space]

	[Header("Stat bars")]
	public GameObject healthBar;
	public GameObject hungerBar;
	public GameObject thirstBar;

	private float health;
	private float hunger;
	private float thirst;


	void Start () {
		health = maxHealth;
		hunger = maxHunger;
		thirst = maxThirst;
	}
	
	void Update () {
		updateStats();
		if (hunger > 0) {
			hunger -= Time.deltaTime / (TimeController.minutesInAFullDayDisplay * 60) * hungerDecayPerDay;
		}

		if (thirst > 0) {
			thirst -= Time.deltaTime / (TimeController.minutesInAFullDayDisplay * 60) * thirstDecayPerDay;
		}

		if (hunger <= 0 && thirst <= 0 && health > 0) {
			health -= Time.deltaTime * healthDecayPerSecond;
		}
	}

	void updateStats () {
		healthBar.transform.localScale = new Vector3(health/maxHealth, 1, 1);
		hungerBar.transform.localScale = new Vector3(hunger/maxHunger, 1, 1);
		thirstBar.transform.localScale = new Vector3(thirst/maxThirst, 1, 1);
	}
}
