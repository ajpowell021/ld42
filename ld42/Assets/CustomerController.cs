using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerController : MonoBehaviour {

	// State

	public int idNumber;
	public Item itemWanted;
	private bool walkAway;
	private bool walkUp;
	private float startTime;
	private Vector3 positionToWalkTo;
	private Vector3 startingPosition;

	// Classes

	private StateManager stateManager;
	private CustomerManager customerManager;
	private OrderPanelManager orderPanelManager;

	// Init

	private void Awake() {
		stateManager = GameObject.FindGameObjectWithTag("Managers").GetComponent<StateManager>();
		customerManager = GameObject.FindGameObjectWithTag("Managers").GetComponent<CustomerManager>();
		orderPanelManager = GameObject.FindGameObjectWithTag("Managers").GetComponent<OrderPanelManager>();
	}

	private void Start() {
		startTime = Time.time;
		startingPosition = transform.position;
		positionToWalkTo = customerManager.getSpawnLocation(idNumber);
		positionToWalkTo.z = 2.32f;
		walkUp = true;
	}

	// Update

	private void Update() {
		if (walkAway) {
			float distCovered = (Time.time - startTime) * stateManager.customerWalkingSpeed;
			float fractionJourney = distCovered / Vector3.Distance(startingPosition, positionToWalkTo);

			gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, positionToWalkTo, fractionJourney);

			if (transform.position.z <= -4.9) {
				Destroy(gameObject);
			}
		}

		if (walkUp) {
			float distCovered = (Time.time - startTime) * stateManager.customerWalkingSpeed;
			float fractionJourney = distCovered / Vector3.Distance(startingPosition, positionToWalkTo);

			gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, positionToWalkTo, fractionJourney);

			if (transform.position.z >= 2.3f) {
				gameObject.transform.eulerAngles = new Vector3(0, 90, 0);
				createRandomRecipe();
				orderPanelManager.setOrderText(idNumber, itemWanted);
				orderPanelManager.showPanel(idNumber);
				walkUp = false;
			}
		}
	}

	// Functions

	public void setId(int newId) {
		idNumber = newId;
	}

	public void createRandomRecipe() {
		int roll = Random.Range(0, 2);

		switch (roll) {

			case 0:
				itemWanted = Item.HOTDOG_WITH_BUN;
				break;
			case 1:
				itemWanted = Item.COOKED_DOG;
				break;
		}
	}

	public void customerLeaves() {
		gameObject.transform.eulerAngles = new Vector3(0, 180, 0);
		startTime = Time.time;
		startingPosition = transform.position;
		positionToWalkTo = transform.position;
		positionToWalkTo.z = -5;
		walkAway = true;
		orderPanelManager.hidePanel(idNumber);
	}
}
