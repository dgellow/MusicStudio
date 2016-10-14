using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class OutputAudio : MonoBehaviour, ICanReceiveAudio {

	public float volumeLevel = 1f;

	#region ICanReceiveAudio implementation

	public void Feed (GameObject inputObject) {
		var audioSource = inputObject.GetComponent<AudioSource> ();
		audioSource.volume = volumeLevel;
		audioSource.Play ();
	}

	#endregion
}
