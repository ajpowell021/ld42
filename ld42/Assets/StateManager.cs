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

	// Functions

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
