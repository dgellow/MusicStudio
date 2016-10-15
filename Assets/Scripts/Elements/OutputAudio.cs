using UnityEngine;
using System.Collections;

public class OutputAudio : MonoBehaviour, ICanReceiveAudio {

	[Range(0, 1)]
	public float volumeLevel = 1f;

	#region ICanReceiveAudio implementation

	public void Feed (GameObject inputObject) {
		Debug.Log ("Feed OutputAudio");
		var audioSource = inputObject.GetComponent<AudioSource> ();
		audioSource.volume = volumeLevel;
		audioSource.Play ();
	}

	#endregion
}
