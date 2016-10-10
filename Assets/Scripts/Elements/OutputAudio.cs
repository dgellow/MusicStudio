using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class OutputAudio : MonoBehaviour, ICanReceiveAudio {

	public AudioSource audioSource;
	
	#region ICanReceiveAudio implementation

	public void Feed (AudioClip sample) {
		audioSource.PlayOneShot (sample);
	}

	#endregion
}
