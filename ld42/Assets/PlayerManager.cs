using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

	// Classes

	private StateManager stateManager;

	// GameObjects

	public GameObject chef;

	// Init

	private void Awake() {
		stateManager = gameObject.GetComponent<StateManager>();
		chef = GameObject.FindGameObjectWithTag("Chef");
	}

	// Public Functions

	public void moveUp() {
		if (stateManager.currentPlayerDirection != PlayerDirection.UP) {
			stateManager.setPlayerDirection(PlayerDirection.UP);
			chef.transform.eulerAngles = new Vector3(0, 0, 0);
		}
	}

	public void moveDown() {
		if (stateManager.currentPlayerDirection != PlayerDirection.DOWN) {
			stateManager.setPlayerDirection(PlayerDirection.DOWN);
			chef.transform.eulerAngles = new Vector3(0, 180, 0);
		}
	}

	public void moveLeft() {
		if (stateManager.currentPlayerPosition != PlayerPostion.LEFT) {
			if (stateManager.currentPlayerPosition == PlayerPostion.CENTER) {
				stateManager.setPlayerPosition(PlayerPostion.LEFT);
				chef.transform.position = new Vector3(3, 1, 6);
			}
			else {
				stateManager.setPlayerPosition(PlayerPostion.CENTER);
				chef.transform.position = new Vector3(5.3f, 1, 6);
			}
		}
	}

	public void moveRight() {
		if (stateManager.currentPlayerPosition != PlayerPostion.RIGHT) {
			if (stateManager.currentPlayerPosition == PlayerPostion.CENTER) {
				stateManager.setPlayerPosition(PlayerPostion.RIGHT);
				chef.transform.position = new Vector3(7.6f, 1, 6);
			}
			else {
				stateManager.setPlayerPosition(PlayerPostion.CENTER);
				chef.transform.position = new Vector3(5.3f, 1, 6);
			}
		}
	}
}
