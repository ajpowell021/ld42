using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerController : MonoBehaviour {

    // State

    private Text timerText;
    private StateManager stateManager;


    private void Start() {
        stateManager = GameObject.FindGameObjectWithTag("Managers").GetComponent<StateManager>();
        timerText = gameObject.GetComponent<Text>();
    }

    // Update
    private void Update() {
        timerText.text = "Shift Ends In:" +  " 0:" + Mathf.Ceil(stateManager.timeUntilShiftEnds);
    }
}
