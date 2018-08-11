using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectorController : MonoBehaviour {

	// State

	public int currentPosition;

	// Init

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
			default:
				Debug.Log("Current position out of range");
				return Item.NONE;
		}
	}

	private void setNewPosition() {
		Vector3 newPos = new Vector3();
		switch (currentPosition) {

			case 0:
				newPos = new Vector3(10, 9.9f, 1.59f);
				break;
			case 1:
				newPos = new Vector3(10, 9.54f, 1.32f);
				break;
			case 2:
				newPos = new Vector3(10, 9.2f, 1);
				break;
			default:
				Debug.Log("Index out of range");
				break;
		}

		gameObject.transform.position = newPos;
	}
}
