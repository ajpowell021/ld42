using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CounterManager : MonoBehaviour {

	// Classes

	private StateManager stateManager;

	// Init

	private void Awake() {
		stateManager = gameObject.GetComponent<StateManager>();
	}

	// Functions

	public List<GameObject> getAllCounters() {
		return GameObject.FindGameObjectsWithTag("CounterController").ToList();
	}

	public Item getItemOnSpecificCounter(CounterPosition counterPosition) {
		List<GameObject> counters = getAllCounters();
		CounterContoller controller = null;
		for (int i = 0; i < counters.Count; i++) {
			controller = counters[i].GetComponent<CounterContoller>();
			if (controller.myCounterPosition == counterPosition) {
				i = counters.Count;
			}
		}

		return controller.currentItemHeld;
	}

	public void setItemHeldOnCounter(CounterPosition counterPosition, Item item) {
		List<GameObject> counters = getAllCounters();
		CounterContoller controller = null;
		for (int i = 0; i < counters.Count; i++) {
			controller = counters[i].GetComponent<CounterContoller>();
			if (controller.myCounterPosition == counterPosition) {
				i = counters.Count;
			}
		}

		if (counterPosition == CounterPosition.HAT) {
			stateManager.setItemInHat(item);
		}

		controller.setCurrentItemHeld(item);
	}
}
