using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StateManager : MonoBehaviour {

	// State

	public int money;

	public float timeUntilShiftEnds;

	public float customerWalkingSpeed;
	public PlayerDirection currentPlayerDirection;
	public PlayerPostion currentPlayerPosition;

	public CounterPosition chefCounterPosition;
	public Item currentHatItem = Item.NONE;

	public float newCustomerTime;
	public float microwaveTime;

	public bool fridgeStored;
	public bool breadBoxStored;
	public bool microwaveStored;
	public bool ketchupStored;
	public bool mustardStored;
	public bool relishStored;

	public float carSpeed;

	public GameObject endGamePanel;
	public bool gameOver;

	public Text moneyText;

	private CameraManager cameraManager;

	// Init

	private void Awake() {
		gameOver = false;
		cameraManager = gameObject.GetComponent<CameraManager>();
	}

	// Update

	private void Update() {
		if (!gameOver) {
			timeUntilShiftEnds -= Time.deltaTime;
		}

		if (timeUntilShiftEnds < 0) {
			cameraManager.hidePanel();
			endGamePanel.SetActive(true);
			gameOver = true;
			timeUntilShiftEnds = 0;
		}
	}

	// Functions

	public void addMoney(int amount) {
		money += amount;
		moneyText.text = "$" + money;
	}

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
			case Item.KETCHUP:
				ketchupStored = set;
				break;
			case Item.MUSTARD:
				mustardStored = set;
				break;
			case Item.RELISH_JAR:
				relishStored = set;
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
			case Item.KETCHUP:
				return ketchupStored;
			case Item.MUSTARD:
				return mustardStored;
			case Item.RELISH_JAR:
				return relishStored;
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
