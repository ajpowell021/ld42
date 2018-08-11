using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectorController : MonoBehaviour {

	// Classes

	private SoundManager soundManager;

	// State

	public int currentPosition;

	// Init

	private void Awake() {
		soundManager = GameObject.FindGameObjectWithTag("Sound").GetComponent<SoundManager>();
	}

	private void Start() {
		setNewPosition();
	}

	// Functions

	public void adjustPosition(int adjust) {
		currentPosition += adjust;
		setNewPosition();
	}

	public Item getItemAtCurrentPosition() {
		switch (currentPosition) {

			case 0:
				return Item.FRIDGE;
			case 1:
				return Item.BREADBOX;
			case 2:
				return Item.MICROWAVE_OFF;
			case 3:
				return Item.KETCHUP;
			case 4:
				return Item.MUSTARD;
			default:
				Debug.Log("Current position out of range");
				return Item.NONE;
		}
	}

	private void setNewPosition() {
		Vector3 newPos = new Vector3();
		switch (currentPosition) {

			case 0:
				newPos = new Vector3(10.36f, 8.567f, 0.523f);
				break;
			case 1:
				newPos = new Vector3(10.36f, 8.202f, 0.251f);
				break;
			case 2:
				newPos = new Vector3(10.36f, 7.813f, -0.038f);
				break;
			case 3:
				newPos = new Vector3(10.36f, 7.474f, -0.289f);
				break;
			case 4:
				newPos = new Vector3(10.36f, 7.121f, -0.552f);
				break;
			default:
				Debug.Log("Index out of range");
				break;
		}

		soundManager.playMovementSound();
		gameObject.transform.position = newPos;
	}
}
