using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

	public AudioSource audioSource;
	public List<AudioClip> clips;

	// Init

	private void Start() {
		audioSource = gameObject.GetComponent<AudioSource>();
	}

	public void playMovementSound() {
		audioSource.clip = clips[0];
		audioSource.Play();
	}

	public void playMicrowaveSound() {
		audioSource.clip = clips[1];
		audioSource.Play();
	}

	public void playMoneySound() {
		audioSource.clip = clips[2];
		audioSource.Play();
	}

	public void playErrorSound() {
		audioSource.clip = clips[3];
		audioSource.Play();
	}

	public void playPutDownSound() {
		audioSource.clip = clips[4];
		audioSource.Play();
	}
}
