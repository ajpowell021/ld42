using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StorageManager : MonoBehaviour {

	public Text fridgeText;
	public Text breadBoxText;
	public Text microWaveText;

	// Classes

	private StateManager stateManager;

	// Init

	private void Awake() {
		stateManager = gameObject.GetComponent<StateManager>();
	}

	private void Start() {
		initTextColors();
	}

	// Private Functions

	private void initTextColors() {
		if (stateManager.fridgeStored) {
			fridgeText.color = Color.black;
		}
		else {
			fridgeText.color = Color.gray;
		}

		if (stateManager.fridgeStored) {
			breadBoxText.color = Color.black;
		}
		else {
			breadBoxText.color = Color.gray;
		}

		if (stateManager.microwaveStored) {
			microWaveText.color = Color.black;
		}
		else {
			microWaveText.color = Color.gray;
		}
	}

	// Public Functions

	public void toggleItemText(Item itemToToggle) {
		switch (itemToToggle) {

			case Item.FRIDGE:
				toggleFridgeText();
				break;
			case Item.BREADBOX:
				toggleBreadBoxText();
				break;
			case Item.MICROWAVE_OFF:
				toggleMicrowaveText();
				break;
			default:
				Debug.Log("Wrong item to toggle.");
				break;
		}
	}

	public void toggleFridgeText() {
		if (stateManager.fridgeStored) {
			stateManager.setStored(Item.FRIDGE, false);
			fridgeText.color = Color.gray;
		}
		else {
			stateManager.setStored(Item.FRIDGE, true);
			fridgeText.color = Color.black;
		}
	}

	public void toggleBreadBoxText() {
		if (stateManager.breadBoxStored) {
			stateManager.setStored(Item.BREADBOX, false);
			breadBoxText.color = Color.gray;
		}
		else {
			stateManager.setStored(Item.BREADBOX, true);
			breadBoxText.color = Color.black;
		}
	}

	public void toggleMicrowaveText() {
		if (stateManager.microwaveStored) {
			stateManager.setStored(Item.MICROWAVE_OFF, false);
			microWaveText.color = Color.gray;
		}
		else {
			stateManager.setStored(Item.MICROWAVE_OFF, true);
			microWaveText.color = Color.black;
		}
	}
}
