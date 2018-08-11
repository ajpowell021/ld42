using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CounterContoller : MonoBehaviour {

	// Public State
	public CounterPosition myCounterPosition;
	public Item currentItemHeld;

	public GameObject hotdog;

	// Classes

	private ItemManager itemManager;

	// Init

	private void Awake() {
		itemManager = GameObject.FindGameObjectWithTag("Managers").GetComponent<ItemManager>();
	}

	// Public Functions

	public void setCurrentItemHeld(Item item) {
		currentItemHeld = item;
		createItemHeld();
	}

	// Private Function

	private void createItemHeld() {
		GameObject newItem = null;
		switch (currentItemHeld) {

			case Item.DOG:
				newItem = Instantiate(hotdog, transform.position, Quaternion.identity);
				break;
			case Item.NONE:
				// Do nothing
				break;
			default:
				Debug.Log("Wrong item held");
				break;
		}

		if (newItem != null) {
			setNewItemsTag(myCounterPosition, newItem);
		}
	}

	private void setNewItemsTag(CounterPosition counterPosition, GameObject newItem) {
		switch (counterPosition) {

			case CounterPosition.BACK_LEFT:
				newItem.tag = "BackLeft";
				break;
			case CounterPosition.BACK_CENTER:
				newItem.tag = "BackCenter";
				break;
			case CounterPosition.BACK_RIGHT:
				newItem.tag = "BackRight";
				break;
			case CounterPosition.FRONT_LEFT:
				newItem.tag = "FrontLeft";
				break;
			case CounterPosition.FRONT_CENTER:
				newItem.tag = "FrontCenter";
				break;
			case CounterPosition.FRONT_RIGHT:
				newItem.tag = "FrontRight";
				break;
			case CounterPosition.HAT:
				newItem.tag = "Hat";
				break;
			default:
				Debug.Log("Wrong counterPosition");
				break;
		}
	}
}
