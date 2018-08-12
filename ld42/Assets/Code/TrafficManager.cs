using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficManager : MonoBehaviour {

	private Vector3 rightLanePos = new Vector3(64.7f, 0.1f, 22.4f);
	private Vector3 leftLanePos = new Vector3(-33.9f, 0.1f, 13.5f);

	public GameObject redCar;
	public GameObject purpleCar;

	private void Start() {
		InvokeRepeating("spawnCarChance", 2, 2);
	}

	private void spawnCarChance() {
		int roll = Random.Range(0, 3);
		int colorRoll = Random.Range(0, 2);

		if (roll == 0) {
			if (colorRoll == 0) {
				Instantiate(redCar, rightLanePos, Quaternion.Euler(0, 90, 0));
			}
			else {
				Instantiate(purpleCar, rightLanePos, Quaternion.Euler(0, 90, 0));
			}
		}
		else if (roll == 1) {
			if (colorRoll == 0) {
				Instantiate(redCar, leftLanePos, Quaternion.Euler(0, -90, 0));
			}
			else {
				Instantiate(purpleCar, leftLanePos, Quaternion.Euler(0, -90, 0));
			}
		}
	}
}
