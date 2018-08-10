using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour {

	// State

	public PlayerDirection currentPlayerDirection;
	public PlayerPostion currentPlayerPosition;
	public Item currentItemHeld;

	// Functions

	public void setPlayerPosition(PlayerPostion newPos) {
		currentPlayerPosition = newPos;
	}

	public void setPlayerDirection(PlayerDirection newDir) {
		currentPlayerDirection = newDir;
	}
}
