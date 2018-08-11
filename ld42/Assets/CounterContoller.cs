using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CounterContoller : MonoBehaviour {

	// Public State
	public CounterPosition myCounterPosition;
	public Item currentItemHeld;

	public GameObject hotdog;
	public GameObject offMicro;
	public GameObject onMicro;
	public GameObject doneMicro;
	public GameObject cookedHotdog;
	public GameObject fridge;

	// Classes

	private ItemManager itemManager;
	private StateManager stateManager;

	// Init

	private void Awake() {
		itemManager = GameObject.FindGameObjectWithTag("Managers").GetComponent<ItemManager>();
		stateManager = GameObject.FindGameObjectWithTag("Managers").GetComponent<StateManager>();
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
			case Item.MICROWAVE_OFF:
				newItem = Instantiate(offMicro, transform.position, Quaternion.Euler(0, 180, 0));
				break;
			case Item.MICROWAVE_COOKING:
				newItem = Instantiate(onMicro, transform.position, Quaternion.Euler(0, 180, 0));
				StartCoroutine(startMicrowaveTimer(stateManager.microwaveTime));
				break;
			case Item.MICROWAVE_DONE:
				newItem = Instantiate(doneMicro, transform.position, Quaternion.Euler(0, 180, 0));
				break;
			case Item.COOKED_DOG:
				newItem = Instantiate(cookedHotdog, transform.position, Quaternion.Euler(0, 180, 0));
				break;
			case Item.FRIDGE:
				newItem = Instantiate(fridge, transform.position, Quaternion.Euler(0, 180, 0));
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

	private IEnumerator startMicrowaveTimer(float amount) {
		yield return new WaitForSeconds(amount);
		itemManager.deleteAllItemsInPosition(myCounterPosition);
		setCurrentItemHeld(Item.MICROWAVE_DONE);
	}
}
