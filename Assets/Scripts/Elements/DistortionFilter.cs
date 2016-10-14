using UnityEngine;
using System.Collections;

[RequireComponent(typeof(IntermediaryElement))]
public class DistortionFilter : MonoBehaviour, ICanSendAudio, ICanReceiveAudio {

	public float distortionLevel;

	GameObject spitObject;

	#region ICanSendAudio implementation

	public GameObject Spit () {
		Debug.Log ("Spit DistortionFilter");
		var outputDistortionFilter = spitObject.AddComponent<AudioDistortionFilter> ();
		outputDistortionFilter.distortionLevel = distortionLevel;
		return spitObject;
	}

	#endregion

	#region ICanReceiveAudio implementation

	public void Feed (GameObject inputObject) {
		Debug.Log ("Feed DistortionFilter");
		spitObject = inputObject;
	}

	#endregion
}
