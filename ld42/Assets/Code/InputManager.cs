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
    private TutorialManager tutorialManager;
    private TutorialState tutorialState;

    // Init

    private void Awake() {
        stateManager = gameObject.GetComponent<StateManager>();
        playerManager = gameObject.GetComponent<PlayerManager>();
        counterManager = gameObject.GetComponent<CounterManager>();
        storageManager = gameObject.GetComponent<StorageManager>();
        customerManager = gameObject.GetComponent<CustomerManager>();
        tutorialManager = gameObject.GetComponent<TutorialManager>();
        tutorialState = GameObject.FindGameObjectWithTag("TutorialState").GetComponent<TutorialState>();
        itemManager = gameObject.GetComponent<ItemManager>();
        soundManager = GameObject.FindGameObjectWithTag("Sound").GetComponent<SoundManager>();
        selectorController = GameObject.FindGameObjectWithTag("Selector").GetComponent<SelectorController>();
    }

    // Update

    private void Update() {
        if (stateManager.gameOver == false) {
            checkMovementInputs();
            checkUseInputs();
            checkPickUpInputs();
            checkSelectorInputs();
            checkRecipeTurnIn();
            checkDeleteButton();
        }
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
        if (Input.GetKeyDown(KeyCode.Z) && stateManager.chefCounterPosition != CounterPosition.STORAGE) {
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

            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Z)) {
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
                        stateManager.addMoney(customerManager.getMoneyFromCustomer(1));
                        customerManager.removeCustomer(1);
                        counterManager.setItemHeldOnCounter(CounterPosition.HAT, Item.NONE);
                        itemManager.deleteAllItemsInPosition(CounterPosition.HAT);
                        soundManager.playMoneySound();
                        if (tutorialState.tutorialOn && tutorialManager.turnInPanelShown) {
                            tutorialManager.setPanel(4, false);
                            tutorialManager.setPanel(5, true);
                        }
                    }
                    else {
                        // No money.
                        customerManager.removeCustomer(1);
                        counterManager.setItemHeldOnCounter(CounterPosition.HAT, Item.NONE);
                        itemManager.deleteAllItemsInPosition(CounterPosition.HAT);
                        soundManager.playErrorSound();
                        if (tutorialState.tutorialOn && tutorialManager.turnInPanelShown) {
                            tutorialManager.setPanel(4, false);
                            tutorialManager.setPanel(5, true);
                        }
                    }
                }

                if (Input.GetKeyDown(KeyCode.Alpha2)) {
                    bool success = customerManager.checkIfRecipeMatchesHeldItem(2);
                    if (success) {
                        stateManager.addMoney(customerManager.getMoneyFromCustomer(2));
                        customerManager.removeCustomer(2);
                        counterManager.setItemHeldOnCounter(CounterPosition.HAT, Item.NONE);
                        itemManager.deleteAllItemsInPosition(CounterPosition.HAT);
                        soundManager.playMoneySound();
                        if (tutorialState.tutorialOn && tutorialManager.turnInPanelShown) {
                            tutorialManager.setPanel(4, false);
                            tutorialManager.setPanel(5, true);
                        }
                    }
                    else {
                        // No money.
                        customerManager.removeCustomer(2);
                        counterManager.setItemHeldOnCounter(CounterPosition.HAT, Item.NONE);
                        itemManager.deleteAllItemsInPosition(CounterPosition.HAT);
                        soundManager.playErrorSound();
                        if (tutorialState.tutorialOn && tutorialManager.turnInPanelShown) {
                            tutorialManager.setPanel(4, false);
                            tutorialManager.setPanel(5, true);
                        }
                    }
                }
                if (Input.GetKeyDown(KeyCode.Alpha3)) {
                    bool success = customerManager.checkIfRecipeMatchesHeldItem(3);
                    if (success) {
                        stateManager.addMoney(customerManager.getMoneyFromCustomer(3));
                        customerManager.removeCustomer(3);
                        counterManager.setItemHeldOnCounter(CounterPosition.HAT, Item.NONE);
                        itemManager.deleteAllItemsInPosition(CounterPosition.HAT);
                        soundManager.playMoneySound();
                        if (tutorialState.tutorialOn && tutorialManager.turnInPanelShown) {
                            tutorialManager.setPanel(4, false);
                            tutorialManager.setPanel(5, true);
                        }
                    }
                    else {
                        // No money.
                        customerManager.removeCustomer(3);
                        counterManager.setItemHeldOnCounter(CounterPosition.HAT, Item.NONE);
                        itemManager.deleteAllItemsInPosition(CounterPosition.HAT);
                        soundManager.playErrorSound();
                        if (tutorialState.tutorialOn && tutorialManager.turnInPanelShown) {
                            tutorialManager.setPanel(4, false);
                            tutorialManager.setPanel(5, true);
                        }
                    }
                }
            }
        }
    }

    private void checkDeleteButton() {
        if (Input.GetKeyDown(KeyCode.X)) {
            if (holdingGarbageItem()) {
                itemManager.deleteAllItemsInPosition(CounterPosition.HAT);
                counterManager.setItemHeldOnCounter(CounterPosition.HAT, Item.NONE);
            }
        }
    }

    private bool holdingForbiddenItem() {
        // Things that cannot be eaten.

        Item item = stateManager.currentHatItem;

        if (item == Item.BREADBOX || item == Item.DOG || item == Item.BUN || item == Item.MICROWAVE_OFF || item == Item.FRIDGE
            || item == Item.KETCHUP || item == Item.MUSTARD || item == Item.RELISH_JAR) {
            return true;
        }
        else {
            return false;
        }
    }

    private bool holdingGarbageItem() {
        // Things that cannot be eaten.

        Item item = stateManager.currentHatItem;

        if (item == Item.BREADBOX || item == Item.MICROWAVE_OFF || item == Item.FRIDGE
            || item == Item.KETCHUP || item == Item.MUSTARD || item == Item.RELISH_JAR) {
            return false;
        }
        else {
            return true;
        }
    }
}
