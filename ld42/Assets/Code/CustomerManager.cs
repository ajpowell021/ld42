using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CustomerManager : MonoBehaviour {

	// Classes

	private StateManager stateManager;

	// Init

	private void Awake() {
		stateManager = gameObject.GetComponent<StateManager>();
	}

	// Functions

	public int getMoneyFromCustomer(int idNumber) {
		GameObject customer = getSpecificCustomer(idNumber);
		CustomerController controller = customer.GetComponent<CustomerController>();
		int money = controller.moneyWhenCompleted;
		float timeStarted = controller.timeArrived;

		if (timeStarted > Time.time - 16) {
			return money;
		}
		else if (timeStarted > Time.time - 20) {
			return money - 2;
		}
		else if (timeStarted > Time.time - 25) {
			return money - 5;
		}
		else {
			return money - 7;
		}
	}

	public Vector3 getSpawnLocation(int idNumber) {
		switch (idNumber) {

			case 1:
				return new Vector3(2.34f, 0, -5);
			case 2:
				return new Vector3(4.38f, 0, -5);
			case 3:
				return new Vector3(6.39f, 0, -5);
		}

		Debug.Log("wrong id number passed");
		return new Vector3(0, 0, 0);
	}

	public bool isRoomForCustomer() {
		return getAllCustomers().Count < 3;
	}

	public int findFirstOpenSpot() {
		if (getSpecificCustomer(1) == null) {
			return 1;
		}
		else if (getSpecificCustomer(2) == null) {
			return 2;
		}
		else {
			return 3;
		}
	}

	public List<GameObject> getAllCustomers() {
		return GameObject.FindGameObjectsWithTag("Customer").ToList();
	}

	public GameObject getSpecificCustomer(int customerId) {
		List<GameObject> customers = getAllCustomers();

		for (int i = 0; i < customers.Count; i++) {
			CustomerController controller = customers[i].GetComponent<CustomerController>();
			if (controller.idNumber == customerId) {
				return customers[i];
			}
		}
		return null;
	}

	public Item getRecipeOfCustomer(int customerId) {
		List<GameObject> customers = getAllCustomers();

		for (int i = 0; i < customers.Count; i++) {
			CustomerController controller = customers[i].GetComponent<CustomerController>();
			if (controller.idNumber == customerId) {
				return controller.itemWanted;
			}
		}

		Debug.Log("customer id out of range.");
		return Item.NONE;
	}

	public bool checkIfRecipeMatchesHeldItem(int customerId) {
		return stateManager.currentHatItem == getRecipeOfCustomer(customerId);
	}

	public void removeCustomer(int customerId) {
		getSpecificCustomer(customerId).GetComponent<CustomerController>().customerLeaves();
	}
}
