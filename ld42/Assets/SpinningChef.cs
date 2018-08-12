using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinningChef : MonoBehaviour {

	public float speed;
	public Vector3 spinningDirection;

	void Update () {
		transform.Rotate(spinningDirection, speed * Time.deltaTime);
	}
}
