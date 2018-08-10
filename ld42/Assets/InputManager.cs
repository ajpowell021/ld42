using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {

    // Classes

    private PlayerManager playerManager;

    // Init

    private void Awake() {
        playerManager = gameObject.GetComponent<PlayerManager>();
    }

    // Update

    private void Update() {
        checkMovementInputs();
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
}
