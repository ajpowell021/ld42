using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StorageManager : MonoBehaviour {

	public Text fridgeText;
	public Text breadBoxText;
	public Text microWaveText;
	public Text ketchupText;
	public Text mustardText;
	public Text relishText;

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

		if (stateManager.ketchupStored) {
			ketchupText.color = Color.black;
		}
		else {
			ketchupText.color = Color.gray;
		}

		if (stateManager.mustardStored) {
			mustardText.color = Color.black;
		}
		else {
			mustardText.color = Color.gray;
		}

		if (stateManager.relishStored) {
			relishText.color = Color.black;
		}
		else {
			relishText.color = Color.gray;
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
			case Item.KETCHUP:
				toggleKetchupText();
				break;
			case Item.MUSTARD:
				toggleMustardText();
				break;
			case Item.RELISH_JAR:
				toggleRelishText();
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

	public void toggleKetchupText() {
		if (stateManager.ketchupStored) {
			stateManager.setStored(Item.KETCHUP, false);
			ketchupText.color = Color.gray;
		}
		else {
			stateManager.setStored(Item.KETCHUP, true);
			ketchupText.color = Color.black;
		}
	}

	public void toggleMustardText() {
		if (stateManager.mustardStored) {
			stateManager.setStored(Item.MUSTARD, false);
			mustardText.color = Color.gray;
		}
		else {
			stateManager.setStored(Item.MUSTARD, true);
			mustardText.color = Color.black;
		}
	}
	public void toggleRelishText() {
		if (stateManager.relishStored) {
			stateManager.setStored(Item.RELISH_JAR, false);
			relishText.color = Color.gray;
		}
		else {
			stateManager.setStored(Item.RELISH_JAR, true);
			relishText.color = Color.black;
		}
	}

}
