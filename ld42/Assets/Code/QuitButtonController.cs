using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitButtonController : MonoBehaviour {

	private void OnMouseDown() {
		Application.Quit();
	}
}
