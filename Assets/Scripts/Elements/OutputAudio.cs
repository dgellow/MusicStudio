using UnityEngine;
using System.Collections;

public class OutputAudio : OutputElement, ICanReceiveAudio {

	[Range(0, 1)]
	public float volumeLevel = 1f;

	public override void Feed (GameObject inputObject) {
		Debug.Log ("Feed OutputAudio");
		var audioSource = inputObject.GetComponent<AudioSource> ();
		audioSource.volume = volumeLevel;
		audioSource.Play ();
	}
}
