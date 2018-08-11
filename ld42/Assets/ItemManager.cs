using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ItemManager : MonoBehaviour {

	// Public Functions

	public List<GameObject> makeListOfItems(CounterPosition counterPosition) {
		List<GameObject> items = new List<GameObject>();

		switch (counterPosition) {

			case CounterPosition.BACK_LEFT:
				items = GameObject.FindGameObjectsWithTag("BackLeft").ToList();
				break;
			case CounterPosition.BACK_CENTER:
				items = GameObject.FindGameObjectsWithTag("BackCenter").ToList();
				break;
			case CounterPosition.BACK_RIGHT:
				items = GameObject.FindGameObjectsWithTag("BackRight").ToList();
				break;
			case CounterPosition.FRONT_LEFT:
				items = GameObject.FindGameObjectsWithTag("FrontLeft").ToList();
				break;
			case CounterPosition.FRONT_CENTER:
				items = GameObject.FindGameObjectsWithTag("FrontCenter").ToList();
				break;
			case CounterPosition.FRONT_RIGHT:
				items = GameObject.FindGameObjectsWithTag("FrontRight").ToList();
				break;
			case CounterPosition.HAT:
				items = GameObject.FindGameObjectsWithTag("Hat").ToList();
				break;
			default:
				Debug.Log("Wrong counter position");
				break;
		}

		return items;
	}

	public GameObject getItemInHat() {
		return GameObject.FindGameObjectWithTag("Hat");
	}

	public void deleteAllItemsInPosition(CounterPosition counterPosition) {
		List<GameObject> items = makeListOfItems(counterPosition);

		for (int i = items.Count - 1; i > -1; i--) {
			Destroy(items[i]);
		}
	}

	public void moveHatItem(Vector3 position) {
		GameObject hatItem = getItemInHat();

		if (hatItem != null) {
			hatItem.transform.position = position;
		}
	}
}
