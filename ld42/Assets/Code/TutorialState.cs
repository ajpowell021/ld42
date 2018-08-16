using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialState : MonoBehaviour {

	public bool tutorialOn;

	private void Awake() {
		DontDestroyOnLoad(gameObject);
	}
}
