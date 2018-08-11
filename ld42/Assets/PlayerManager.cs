using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

	// Classes

	private StateManager stateManager;
	private CounterManager counterManager;
	private ItemManager itemManager;

	// GameObjects

	public GameObject chef;

	// Init

	private void Awake() {
		stateManager = gameObject.GetComponent<StateManager>();
		counterManager = gameObject.GetComponent<CounterManager>();
		itemManager = gameObject.GetComponent<ItemManager>();
		chef = GameObject.FindGameObjectWithTag("Chef");
	}

	// Public Functions

	public void moveUp() {
		if (stateManager.currentPlayerDirection != PlayerDirection.UP) {
			stateManager.setPlayerDirection(PlayerDirection.UP);
			chef.transform.eulerAngles = new Vector3(0, 0, 0);
		}
	}

	public void moveDown() {
		if (stateManager.currentPlayerDirection != PlayerDirection.DOWN) {
			stateManager.setPlayerDirection(PlayerDirection.DOWN);
			chef.transform.eulerAngles = new Vector3(0, 180, 0);
		}
	}

	public void moveLeft() {
		if (stateManager.currentPlayerPosition != PlayerPostion.LEFT) {
			if (stateManager.currentPlayerPosition == PlayerPostion.CENTER) {
				stateManager.setPlayerPosition(PlayerPostion.LEFT);
				chef.transform.position = new Vector3(3, 1, 6);
				itemManager.moveHatItem(new Vector3(3, 3.7f, 6));
			}
			else {
				stateManager.setPlayerPosition(PlayerPostion.CENTER);
				chef.transform.position = new Vector3(5.3f, 1, 6);
				itemManager.moveHatItem(new Vector3(5.3f, 3.7f, 6));
			}
		}
	}

	public void moveRight() {
		if (stateManager.currentPlayerPosition != PlayerPostion.RIGHT) {
			if (stateManager.currentPlayerPosition == PlayerPostion.CENTER) {
				stateManager.setPlayerPosition(PlayerPostion.RIGHT);
				chef.transform.position = new Vector3(7.6f, 1, 6);
				itemManager.moveHatItem(new Vector3(7.6f, 3.7f, 6));
			}
			else {
				stateManager.setPlayerPosition(PlayerPostion.CENTER);
				chef.transform.position = new Vector3(5.3f, 1, 6);
				itemManager.moveHatItem(new Vector3(5.3f, 3.7f, 6));
			}
		}
	}

	public void pickUp() {
		if (stateManager.currentHatItem == Item.NONE) {
			// Attempt to use counter.
			Item counterItem = counterManager.getItemOnSpecificCounter(stateManager.chefCounterPosition);
			emptyPlayerAction(counterItem);
		}
		else {
			// Attempt to set thing down.
			Item counterItem = counterManager.getItemOnSpecificCounter(stateManager.chefCounterPosition);
			setDownItemPlayerAction(counterItem);
		}
	}

	// Private Functions

	private void emptyPlayerAction(Item counterItem) {

		// Player has nothing in hat.

		switch (counterItem) {

			case Item.DOG:
				// Picks up hotdog.
				itemManager.deleteAllItemsInPosition(stateManager.chefCounterPosition);
				counterManager.setItemHeldOnCounter(CounterPosition.HAT, counterItem);
				counterManager.setItemHeldOnCounter(stateManager.chefCounterPosition, Item.NONE);
				stateManager.setItemInHat(counterItem);
				break;
			case Item.NONE:
				Debug.Log("No item held, no item on counter");
				break;
			default:
				Debug.Log("Wrong item");
				break;
		}
	}

	private void setDownItemPlayerAction(Item counterItem) {
		// Player has something in hat.

		switch (counterItem) {

			case Item.NONE:
				itemManager.deleteAllItemsInPosition(CounterPosition.HAT);
				counterManager.setItemHeldOnCounter(stateManager.chefCounterPosition, stateManager.currentHatItem);
				stateManager.setItemInHat(Item.NONE);
				break;
			default:
				Debug.Log("Wrong item set down");
				break;
		}
	}
}
