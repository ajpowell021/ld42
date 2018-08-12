using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerController : MonoBehaviour {

	// State

	public int idNumber;
	public Item itemWanted;
	public int moneyWhenCompleted;
	public float timeArrived;
	private bool walkAway;
	private bool walkUp;
	private float startTime;
	private Vector3 positionToWalkTo;
	private Vector3 startingPosition;

	private MeshFilter meshFilter;
	private MeshRenderer meshRenderer;
	public Mesh cust1Mesh;
	public Material cust1Mat;
	public Mesh cust2Mesh;
	public Material cust2Mat;
	public Mesh cust3Mesh;
	public Material cust3Mat;
	public Mesh cust4Mesh;
	public Material cust4Mat;

	// Classes

	private StateManager stateManager;
	private CustomerManager customerManager;
	private OrderPanelManager orderPanelManager;

	// Init

	private void Awake() {
		stateManager = GameObject.FindGameObjectWithTag("Managers").GetComponent<StateManager>();
		customerManager = GameObject.FindGameObjectWithTag("Managers").GetComponent<CustomerManager>();
		orderPanelManager = GameObject.FindGameObjectWithTag("Managers").GetComponent<OrderPanelManager>();
		meshFilter = gameObject.GetComponent<MeshFilter>();
		meshRenderer = gameObject.GetComponent<MeshRenderer>();
	}

	private void Start() {
		startTime = Time.time;
		startingPosition = transform.position;
		positionToWalkTo = customerManager.getSpawnLocation(idNumber);
		positionToWalkTo.z = 2.32f;
		walkUp = true;
		randomizeModel();
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

	private void randomizeModel() {
		int roll = Random.Range(0, 4);

		switch (roll) {


			case 0:
				meshFilter.mesh = cust1Mesh;
				meshRenderer.material = cust1Mat;
				break;
			case 1:
				meshFilter.mesh = cust2Mesh;
				meshRenderer.material = cust2Mat;
				break;
			case 2:
				meshFilter.mesh = cust3Mesh;
				meshRenderer.material = cust3Mat;
				break;
			case 3:
				meshFilter.mesh = cust4Mesh;
				meshRenderer.material = cust4Mat;
				break;

		}
	}

	public void setId(int newId) {
		idNumber = newId;
	}

	public void createRandomRecipe() {
		int roll = Random.Range(0, 8);

		switch (roll) {

			case 0:
				itemWanted = Item.HOTDOG_WITH_BUN;
				break;
			case 1:
				itemWanted = Item.COOKED_DOG;
				break;
			case 2:
				itemWanted = Item.HOTDOG_BUN_W_KETCHUP;
				break;
			case 3:
				itemWanted = Item.HOTDOG_BUN_W_MUSTARD;
				break;
			case 4:
				itemWanted = Item.HOTDOG_K_AND_M;
				break;
			case 5:
				itemWanted = Item.HOTDOG_RELISH;
				break;
			case 6:
				itemWanted = Item.HOTDOG_RELISH_MUSTARD;
				break;
			case 7:
				itemWanted = Item.HOTDOG_RELISH_KETCHUP;
				break;
		}

		moneyWhenCompleted = 10;
		timeArrived = Time.time;
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
