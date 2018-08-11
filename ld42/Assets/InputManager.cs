using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {

    // Classes

    private StateManager stateManager;
    private PlayerManager playerManager;

    // Init

    private void Awake() {
        stateManager = gameObject.GetComponent<StateManager>();
        playerManager = gameObject.GetComponent<PlayerManager>();
    }

    // Update

    private void Update() {
        checkMovementInputs();
        checkPickInputs();
    }

    // Functions

    private void checkMovementInputs() {
        if (Input.GetKeyDown(KeyCode.LeftArrow)) {
            playerManager.moveLeft();
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow)) {
            playerManager.moveRight();
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow)) {
            playerManager.moveUp();
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow)) {
            playerManager.moveDown();
        }
    }

    private void checkPickInputs() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            playerManager.pickUp();
        }
    }
}
