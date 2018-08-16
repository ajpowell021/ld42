using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootTrafficController : MonoBehaviour {

	// Classes

	private StateManager stateManager;

	// Init

	private void Awake() {
		stateManager = GameObject.FindGameObjectWithTag("Managers").GetComponent<StateManager>();
	}

	// Update

	void Update() {
		if (stateManager != null) {
			transform.Translate(Vector3.forward * Time.deltaTime * stateManager.peopleSpeed);
		}
	}

	private void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag("CarKilla")) {
			Destroy(gameObject);
		}
	}
}
