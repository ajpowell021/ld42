using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

	// Classes

	private StateManager stateManager;
	private CounterManager counterManager;
	private ItemManager itemManager;
	private CameraManager cameraManager;
	private StorageManager storageManager;
	private SelectorController selectorController;
	private SoundManager soundManager;

	// GameObjects

	public GameObject chef;

	// Init

	private void Awake() {
		stateManager = gameObject.GetComponent<StateManager>();
		counterManager = gameObject.GetComponent<CounterManager>();
		itemManager = gameObject.GetComponent<ItemManager>();
		cameraManager = gameObject.GetComponent<CameraManager>();
		storageManager = gameObject.GetComponent<StorageManager>();
		soundManager = GameObject.FindGameObjectWithTag("Sound").GetComponent<SoundManager>();
		chef = GameObject.FindGameObjectWithTag("Chef");
		selectorController = GameObject.FindGameObjectWithTag("Selector").GetComponent<SelectorController>();
	}

	// Public Functions

	public void moveUp() {
		if (stateManager.currentPlayerPosition != PlayerPostion.STORAGE) {
			if (stateManager.currentPlayerDirection != PlayerDirection.UP) {
				stateManager.setPlayerDirection(PlayerDirection.UP);
				chef.transform.eulerAngles = new Vector3(0, 0, 0);
				soundManager.playMovementSound();
			}
		}
	}

	public void moveDown() {
		if (stateManager.currentPlayerPosition != PlayerPostion.STORAGE) {
			if (stateManager.currentPlayerDirection != PlayerDirection.DOWN) {
				stateManager.setPlayerDirection(PlayerDirection.DOWN);
				chef.transform.eulerAngles = new Vector3(0, 180, 0);
				soundManager.playMovementSound();
			}
		}
	}

	public void moveLeft() {
		if (stateManager.currentPlayerPosition == PlayerPostion.STORAGE) {
			stateManager.setPlayerPosition(PlayerPostion.RIGHT);
			stateManager.setPlayerDirection(PlayerDirection.DOWN);
			chef.transform.eulerAngles = new Vector3(0, 180, 0);
			soundManager.playMovementSound();
			cameraManager.hidePanel();
		}
		else if (stateManager.currentPlayerPosition != PlayerPostion.LEFT) {
			if (stateManager.currentPlayerPosition == PlayerPostion.CENTER) {
				stateManager.setPlayerPosition(PlayerPostion.LEFT);
				chef.transform.position = new Vector3(3, 1, 6);
				itemManager.moveHatItem(new Vector3(3, 3.7f, 6));
				soundManager.playMovementSound();
			}
			else {
				stateManager.setPlayerPosition(PlayerPostion.CENTER);
				chef.transform.position = new Vector3(5.3f, 1, 6);
				itemManager.moveHatItem(new Vector3(5.3f, 3.7f, 6));
				soundManager.playMovementSound();
			}
		}
	}

	public void moveRight() {
		if (stateManager.currentPlayerPosition != PlayerPostion.RIGHT && stateManager.currentPlayerPosition != PlayerPostion.STORAGE) {
			if (stateManager.currentPlayerPosition == PlayerPostion.CENTER) {
				stateManager.setPlayerPosition(PlayerPostion.RIGHT);
				chef.transform.position = new Vector3(7.6f, 1, 6);
				itemManager.moveHatItem(new Vector3(7.6f, 3.7f, 6));
				soundManager.playMovementSound();
			}
			else {
				stateManager.setPlayerPosition(PlayerPostion.CENTER);
				chef.transform.position = new Vector3(5.3f, 1, 6);
				itemManager.moveHatItem(new Vector3(5.3f, 3.7f, 6));
				soundManager.playMovementSound();
			}
		}
		else if(stateManager.currentPlayerPosition != PlayerPostion.STORAGE) {
			stateManager.setPlayerPosition(PlayerPostion.STORAGE);
			cameraManager.showPanel();
			chef.transform.eulerAngles = new Vector3(0, 90, 0);
			soundManager.playMovementSound();
		}
	}

	public void use() {
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

	public void pickUp() {
		if (stateManager.currentHatItem == Item.NONE) {
			Item counterItem = counterManager.getItemOnSpecificCounter(stateManager.chefCounterPosition);
			playerPickUpAction(counterItem);
		}
		else {
			Debug.Log("Already holding somthing.");
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
				break;
			case Item.COOKED_DOG:
				// Picks up cooked hotdog.
				itemManager.deleteAllItemsInPosition(stateManager.chefCounterPosition);
				counterManager.setItemHeldOnCounter(CounterPosition.HAT, counterItem);
				counterManager.setItemHeldOnCounter(stateManager.chefCounterPosition, Item.NONE);
				break;
			case Item.BUN:
				// Picks up bun.
				itemManager.deleteAllItemsInPosition(stateManager.chefCounterPosition);
				counterManager.setItemHeldOnCounter(CounterPosition.HAT, counterItem);
				counterManager.setItemHeldOnCounter(stateManager.chefCounterPosition, Item.NONE);
				break;
			case Item.HOTDOG_WITH_BUN:
				// Picks up finished dog.
				itemManager.deleteAllItemsInPosition(stateManager.chefCounterPosition);
				counterManager.setItemHeldOnCounter(CounterPosition.HAT, counterItem);
				counterManager.setItemHeldOnCounter(stateManager.chefCounterPosition, Item.NONE);
				break;
			case Item.MICROWAVE_COOKING:
				Debug.Log("Not done cooking");
				break;
			case Item.MICROWAVE_DONE:
				// Get cooked hotdog from microwave.
				itemManager.deleteAllItemsInPosition(stateManager.chefCounterPosition);
				counterManager.setItemHeldOnCounter(CounterPosition.HAT, Item.COOKED_DOG);
				counterManager.setItemHeldOnCounter(stateManager.chefCounterPosition, Item.MICROWAVE_OFF);
				break;
			case Item.FRIDGE:
				// Get hotdog from fridge.
				counterManager.setItemHeldOnCounter(CounterPosition.HAT, Item.DOG);
				break;
			case Item.BREADBOX:
				// Get bun from breadbox.
				counterManager.setItemHeldOnCounter(CounterPosition.HAT, Item.BUN);
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
				counterManager.setItemHeldOnCounter(stateManager.chefCounterPosition, stateManager.currentHatItem);
				itemManager.deleteAllItemsInPosition(CounterPosition.HAT);
				counterManager.setItemHeldOnCounter(CounterPosition.HAT, Item.NONE);
				break;
			case Item.MICROWAVE_OFF:
				// Using a uncooked hotdog on a off microwave.
				if (stateManager.currentHatItem == Item.DOG) {
					itemManager.deleteAllItemsInPosition(CounterPosition.HAT);
					itemManager.deleteAllItemsInPosition(stateManager.chefCounterPosition);
					counterManager.setItemHeldOnCounter(stateManager.chefCounterPosition, Item.MICROWAVE_COOKING);
					counterManager.setItemHeldOnCounter(CounterPosition.HAT, Item.NONE);
				}
				break;
			case Item.FRIDGE:
				if (stateManager.currentHatItem == Item.DOG) {
					// Put uncooked hotdog back in fridge.
					itemManager.deleteAllItemsInPosition(CounterPosition.HAT);
					counterManager.setItemHeldOnCounter(CounterPosition.HAT, Item.NONE);
				}
				break;
			case Item.BREADBOX:
				if (stateManager.currentHatItem == Item.BUN) {
					// Put bun back in box.
					itemManager.deleteAllItemsInPosition(CounterPosition.HAT);
					counterManager.setItemHeldOnCounter(CounterPosition.HAT, Item.NONE);
				}
				break;
			case Item.BUN:
				if (stateManager.currentHatItem == Item.COOKED_DOG) {
					// Put cooked dog into bun.
					itemManager.deleteAllItemsInPosition(CounterPosition.HAT);
					itemManager.deleteAllItemsInPosition(stateManager.chefCounterPosition);
					counterManager.setItemHeldOnCounter(stateManager.chefCounterPosition, Item.HOTDOG_WITH_BUN);
					counterManager.setItemHeldOnCounter(CounterPosition.HAT, Item.NONE);
				}
				break;
			default:
				Debug.Log("Wrong item set down");
				break;
		}
	}

	private void playerPickUpAction(Item counterItem) {
		counterManager.setItemHeldOnCounter(CounterPosition.HAT, counterItem);
		itemManager.deleteAllItemsInPosition(stateManager.chefCounterPosition);
		counterManager.setItemHeldOnCounter(stateManager.chefCounterPosition, Item.NONE);
	}

	public void playerStorageAction() {
		if (stateManager.currentHatItem == Item.NONE) {
			// Try to get item from storage.
			Item itemToGet = selectorController.getItemAtCurrentPosition();
			if (stateManager.checkIfItemIsStored(itemToGet)) {
				// Get item from storage.
				storageManager.toggleItemText(itemToGet);
				counterManager.setItemHeldOnCounter(CounterPosition.HAT, itemToGet);
			}
			else {
				Debug.Log("Item is already out");
			}
		}
		else {
			// Try to put item in storage.
			Item heldItem = stateManager.currentHatItem;

			switch (heldItem) {

				case Item.FRIDGE:
					storageManager.toggleFridgeText();
					counterManager.setItemHeldOnCounter(CounterPosition.HAT, Item.NONE);
					itemManager.deleteAllItemsInPosition(CounterPosition.HAT);
					break;
				case Item.BREADBOX:
					storageManager.toggleBreadBoxText();
					counterManager.setItemHeldOnCounter(CounterPosition.HAT, Item.NONE);
					itemManager.deleteAllItemsInPosition(CounterPosition.HAT);
					break;
				case Item.MICROWAVE_OFF:
					storageManager.toggleMicrowaveText();
					counterManager.setItemHeldOnCounter(CounterPosition.HAT, Item.NONE);
					itemManager.deleteAllItemsInPosition(CounterPosition.HAT);
					break;
				default:
					Debug.Log("held item not handled.");
					break;
			}
		}
	}
}
