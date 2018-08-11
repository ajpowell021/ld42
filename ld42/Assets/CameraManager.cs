using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour {

	// Public State

	public float driftSpeed;

	// Private State

	private float startTime;
	private bool moveCamRight;
	private bool moveCamLeft;
	private GameObject cam;

	// Init

	private void Awake() {
		cam = GameObject.FindGameObjectWithTag("MainCamera");
	}

	// Update

	private void Update() {
		if (cam != null) {
			if (moveCamRight) {
				float distCovered = (Time.time - startTime) * driftSpeed;
				float fractionJourney = distCovered / 4;

				cam.transform.position = Vector3.Lerp(cam.transform.position, new Vector3(9, 12, -3), fractionJourney);
				if (cam.transform.position.x >= 9) {
					moveCamRight = false;
				}
			}

			if (moveCamLeft) {
				float distCoverer = (Time.time - startTime) * driftSpeed;
				float fractionJourney = distCoverer / 4;

				cam.transform.position = Vector3.Lerp(cam.transform.position, new Vector3(4, 12, -3), fractionJourney);
				if (cam.transform.position.x <= 5) {
					moveCamLeft = false;
				}
			}
		}
	}

	// Public Functions

	public void showPanel() {
		startTime = Time.time;
		moveCamRight = true;
		moveCamLeft = false;
	}

	public void hidePanel() {
		startTime = Time.time;
		moveCamLeft = true;
		moveCamRight = false;
	}
}
