using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {

    // Classes

    private StateManager stateManager;
    private PlayerManager playerManager;
    private SelectorController selectorController;
    private CounterManager counterManager;
    private StorageManager storageManager;
    private ItemManager itemManager;

    // Init

    private void Awake() {
        stateManager = gameObject.GetComponent<StateManager>();
        playerManager = gameObject.GetComponent<PlayerManager>();
        counterManager = gameObject.GetComponent<CounterManager>();
        storageManager = gameObject.GetComponent<StorageManager>();
        itemManager = gameObject.GetComponent<ItemManager>();
        selectorController = GameObject.FindGameObjectWithTag("Selector").GetComponent<SelectorController>();
    }

    // Update

    private void Update() {
        checkMovementInputs();
        checkUseInputs();
        checkPickUpInputs();
        checkSelectorInputs();
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

    private void checkUseInputs() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            if (stateManager.currentPlayerPosition != PlayerPostion.STORAGE) {
                playerManager.use();
            }
        }
    }

    private void checkPickUpInputs() {
        if (Input.GetKeyDown(KeyCode.Z)) {
            playerManager.pickUp();
        }
    }

    private void checkSelectorInputs() {
        if (stateManager.currentPlayerPosition == PlayerPostion.STORAGE) {
            if (Input.GetKeyDown(KeyCode.UpArrow)) {
                selectorController.adjustPosition(-1);
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow)) {
                selectorController.adjustPosition(1);
            }

            if (Input.GetKeyDown(KeyCode.Space)) {
               playerManager.playerStorageAction();
            }
        }
    }
}
