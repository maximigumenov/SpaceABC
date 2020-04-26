using UnityEngine;
using System.Collections;

public class doorСont : MonoBehaviour {

	Animator animator;
	AudioSource audioSource;
	bool doorOpen;


	void Start () {
		doorOpen = false;
		animator = GetComponent<Animator> ();
		audioSource = GetComponent<AudioSource> ();

	}

	void OnTriggerEnter(Collider col) {
		if (col.gameObject.tag == "Player") {
			doorOpen = true;
			DoorConte ("Open");
			audioSource.Play();
		}
	}

	void OnTriggerExit(Collider col) {
		if (doorOpen) {
			doorOpen = false;
			DoorConte ("Close");
			audioSource.Play();
		}
	}

	void DoorConte(string direction) {
		animator.SetTrigger (direction);
	}

}
