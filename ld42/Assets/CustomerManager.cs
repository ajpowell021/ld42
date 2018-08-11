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

		Debug.Log("No customer matching id");
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
