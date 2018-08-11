using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {

    // Classes

    private StateManager stateManager;
    private PlayerManager playerManager;
    private SelectorController selectorController;
    private CustomerManager customerManager;
    private CounterManager counterManager;
    private StorageManager storageManager;
    private ItemManager itemManager;
    private SoundManager soundManager;

    // Init

    private void Awake() {
        stateManager = gameObject.GetComponent<StateManager>();
        playerManager = gameObject.GetComponent<PlayerManager>();
        counterManager = gameObject.GetComponent<CounterManager>();
        storageManager = gameObject.GetComponent<StorageManager>();
        customerManager = gameObject.GetComponent<CustomerManager>();
        itemManager = gameObject.GetComponent<ItemManager>();
        soundManager = GameObject.FindGameObjectWithTag("Sound").GetComponent<SoundManager>();
        selectorController = GameObject.FindGameObjectWithTag("Selector").GetComponent<SelectorController>();
    }

    // Update

    private void Update() {
        checkMovementInputs();
        checkUseInputs();
        checkPickUpInputs();
        checkSelectorInputs();
        checkRecipeTurnIn();
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

    private void checkRecipeTurnIn() {
        if (stateManager.currentHatItem != Item.NONE) {
            if (!holdingForbiddenItem()) {
                if (Input.GetKeyDown(KeyCode.Alpha1)) {
                    bool success = customerManager.checkIfRecipeMatchesHeldItem(1);
                    if (success) {
                        stateManager.addMoney(5);
                        customerManager.removeCustomer(1);
                        counterManager.setItemHeldOnCounter(CounterPosition.HAT, Item.NONE);
                        itemManager.deleteAllItemsInPosition(CounterPosition.HAT);
                        soundManager.playMoneySound();
                    }
                    else {
                        // No money.
                        customerManager.removeCustomer(1);
                        counterManager.setItemHeldOnCounter(CounterPosition.HAT, Item.NONE);
                        itemManager.deleteAllItemsInPosition(CounterPosition.HAT);
                        soundManager.playErrorSound();
                    }
                }
            }
        }
    }

    private bool holdingForbiddenItem() {
        // Things that cannot be eaten.

        Item item = stateManager.currentHatItem;

        if (item == Item.BREADBOX || item == Item.DOG || item == Item.BUN || item == Item.MICROWAVE_OFF || item == Item.FRIDGE) {
            return true;
        }
        else {
            return false;
        }
    }
}
