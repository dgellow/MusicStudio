using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DistortionFilter : IntermediaryElement {

	[Range(0, 1)]
	public float distortionLevel;

	GameObject spitObject;

	public override GameObject Spit () {
		Debug.Log ("Spit DistortionFilter");
		var outputDistortionFilter = spitObject.AddComponent<AudioDistortionFilter> ();
		outputDistortionFilter.distortionLevel = distortionLevel;
		return spitObject;
	}

	public override void Feed (GameObject inputObject) {
		Debug.Log ("Feed DistortionFilter");
		spitObject = inputObject;
	}
}
