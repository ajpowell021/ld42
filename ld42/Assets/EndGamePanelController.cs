using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGamePanelController : MonoBehaviour {

    private StateManager stateManager;

    private void OnEnable() {
        stateManager = GameObject.FindGameObjectWithTag("Managers").GetComponent<StateManager>();

        Text moneyText = GameObject.FindGameObjectWithTag("MoneyText").GetComponent<Text>();

        moneyText.text = "Money Earned: $" + stateManager.money;
    }
}
