using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour {

	// State

	public PlayerDirection currentPlayerDirection;
	public PlayerPostion currentPlayerPosition;

	public CounterPosition chefCounterPosition;
	public Item currentHatItem = Item.NONE;

	public float microwaveTime;

	public bool fridgeStored;
	public bool breadBoxStored;
	public bool microwaveStored;

	// Functions

	public void setStored(Item item, bool set) {
		switch (item) {

			case Item.FRIDGE:
				fridgeStored = set;
				break;
			case Item.BREADBOX:
				breadBoxStored = set;
				break;
			case Item.MICROWAVE_OFF:
				microwaveStored = set;
				break;
			default:
				Debug.Log("Can't store item");
				break;
		}
	}

	public bool checkIfItemIsStored(Item item) {

		switch (item) {

			case Item.FRIDGE:
				return fridgeStored;
			case Item.BREADBOX:
				return breadBoxStored;
			case Item.MICROWAVE_OFF:
				return microwaveStored;
			default:
				Debug.Log("Wrong item type.");
				return false;
		}
	}


	public void setPlayerPosition(PlayerPostion newPos) {
		currentPlayerPosition = newPos;
		setChefCounterPosition();
	}

	public void setPlayerDirection(PlayerDirection newDir) {
		currentPlayerDirection = newDir;
		setChefCounterPosition();
	}


	public void setItemInHat(Item item) {
		currentHatItem = item;
	}

	// Private Functions

	private void setChefCounterPosition() {
		if (currentPlayerDirection == PlayerDirection.UP
		    && currentPlayerPosition == PlayerPostion.LEFT) {
			chefCounterPosition = CounterPosition.BACK_LEFT;
		}
		else if (currentPlayerDirection == PlayerDirection.UP
		    && currentPlayerPosition == PlayerPostion.CENTER) {
			chefCounterPosition = CounterPosition.BACK_CENTER;
		}
		else if (currentPlayerDirection == PlayerDirection.UP
		    && currentPlayerPosition == PlayerPostion.RIGHT) {
			chefCounterPosition = CounterPosition.BACK_RIGHT;
		}
		else if (currentPlayerDirection == PlayerDirection.DOWN
		         && currentPlayerPosition == PlayerPostion.LEFT) {
			chefCounterPosition = CounterPosition.FRONT_LEFT;
		}
		else if (currentPlayerDirection == PlayerDirection.DOWN
		         && currentPlayerPosition == PlayerPostion.CENTER) {
			chefCounterPosition = CounterPosition.FRONT_CENTER;
		}
		else if (currentPlayerDirection == PlayerDirection.DOWN
		         && currentPlayerPosition == PlayerPostion.RIGHT) {
			chefCounterPosition = CounterPosition.FRONT_RIGHT;
		}
		else if (currentPlayerPosition == PlayerPostion.STORAGE) {
			chefCounterPosition = CounterPosition.STORAGE;
		}
	}
}
