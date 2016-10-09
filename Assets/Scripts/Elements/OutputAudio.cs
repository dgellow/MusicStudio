using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class OutputAudio : MonoBehaviour, ICanReceiveAudio {

	public AudioSource source;
	
	#region ICanReceiveAudio implementation

	public void Feed (AudioClip sample) {
		source.PlayOneShot (sample);
	}

	#endregion
}
