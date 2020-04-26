using UnityEngine;
using System.Collections;

public class doorCloseAlarm : MonoBehaviour {

	AudioSource audioSource;

	void Start () {
		audioSource = GetComponent<AudioSource> ();
	}
	
	void OnTriggerEnter(Collider col) {
		if (col.gameObject.tag == "Player") {
			audioSource.Play();
		}
	}
}
