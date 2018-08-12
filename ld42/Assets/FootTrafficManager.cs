using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootTrafficManager : MonoBehaviour {

	private Vector3 rightLanePos = new Vector3(-39.4f, 0f, 31.5f); // y = 90 for rotate
	private Vector3 leftLanePos = new Vector3(64.5f, 0f, 35.7f); // y = -90 for rotate

	public GameObject person1;
	public GameObject person2;
	public GameObject person3;
	public GameObject person4;

	private void Start() {
		InvokeRepeating("spawnCarChance", 3, 3);
	}

	private void spawnCarChance() {
		int roll = Random.Range(0, 3);
		int colorRoll = Random.Range(0, 4);

		if (roll == 0) {
			if (colorRoll == 0) {
				Instantiate(person1, rightLanePos, Quaternion.Euler(0, 90, 0));
			}
			else if (colorRoll == 1) {
				Instantiate(person2, rightLanePos, Quaternion.Euler(0, 90, 0));
			}
			if (colorRoll == 2) {
				Instantiate(person3, rightLanePos, Quaternion.Euler(0, 90, 0));
			}
			else if (colorRoll == 3) {
				Instantiate(person4, rightLanePos, Quaternion.Euler(0, 90, 0));
			}
		}
		else if (roll == 1) {
			if (colorRoll == 0) {
				Instantiate(person1, leftLanePos, Quaternion.Euler(0, -90, 0));
			}
			else if (colorRoll == 1) {
				Instantiate(person2, leftLanePos, Quaternion.Euler(0, -90, 0));
			}
			if (colorRoll == 2) {
				Instantiate(person3, leftLanePos, Quaternion.Euler(0, -90, 0));
			}
			else if (colorRoll == 3) {
				Instantiate(person4, leftLanePos, Quaternion.Euler(0, -90, 0));
			}
		}
	}
}
