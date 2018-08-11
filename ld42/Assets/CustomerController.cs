using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerController : MonoBehaviour {

	// State

	public int idNumber;
	public Item itemWanted;
	private bool walkAway;
	private float startTime;
	private Vector3 positionToWalkTo;
	private Vector3 startingPosition;

	// Classes

	private StateManager stateManager;

	// Init

	private void Awake() {
		stateManager = GameObject.FindGameObjectWithTag("Managers").GetComponent<StateManager>();
	}

	private void Start() {
		createRandomRecipe();
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
	}

	// Functions

	public void createRandomRecipe() {
		int roll = Random.Range(0, 1);

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
	}
}
