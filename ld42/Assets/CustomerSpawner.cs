using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerSpawner : MonoBehaviour {

	// Classes

	private StateManager stateManager;
	private CustomerManager customerManager;


	// Public State

	public GameObject customer;

	// Private State

	private float lastSpawn;
	private float nextSpawn;

	// Init

	private void Awake() {
		stateManager = gameObject.GetComponent<StateManager>();
		customerManager = gameObject.GetComponent<CustomerManager>();
	}

	private void Start() {
		nextSpawn = stateManager.newCustomerTime;
	}

	// Update

	private void Update() {
		spawnCheck();
	}

	private void spawnCheck() {
		if (Time.time > nextSpawn) {
			if (customerManager.isRoomForCustomer()) {
				int newId = customerManager.findFirstOpenSpot();
				Vector3 newSpawnLocation = customerManager.getSpawnLocation(newId);
				GameObject newCustomer = Instantiate(customer, newSpawnLocation, Quaternion.identity);
				newCustomer.GetComponent<CustomerController>().setId(newId);
			}
			lastSpawn = Time.time;
			nextSpawn = lastSpawn + stateManager.newCustomerTime;
		}
	}
}
