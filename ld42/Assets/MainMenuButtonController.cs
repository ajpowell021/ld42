﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtonController : MonoBehaviour {

	private void OnMouseDown() {
		SceneManager.LoadScene("MainMenu");
	}
}
