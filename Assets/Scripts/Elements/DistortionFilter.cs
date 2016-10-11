using UnityEngine;
using System.Collections;

[RequireComponent(typeof(IntermediaryElement))]
public class DistortionFilter : MonoBehaviour, ICanSendAudio, ICanReceiveAudio {

	public float distortionLevel;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	#region ICanSendAudio implementation

	public AudioClip Spit () {
		throw new System.NotImplementedException ();
	}

	#endregion

	#region ICanReceiveAudio implementation

	public void Feed (AudioClip sample) {
		throw new System.NotImplementedException ();
	}

	#endregion
}
