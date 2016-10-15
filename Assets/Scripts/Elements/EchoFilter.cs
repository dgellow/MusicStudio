using UnityEngine;
using System.Collections;

public class EchoFilter : IntermediaryElement {

	[Range(10, 5000)]
	public float delay = 500f;
	[Range(0, 1)]
	public float decayRatio = .5f;
	[Range(0, 1)]
	public float wetMix = .5f;
	[Range(0, 1)]
	public float dryMix = .2f;

	GameObject spitObject;

	public override GameObject Spit () {
		Debug.Log ("Spit EchoFilter");
		var outputEchoFilter = spitObject.AddComponent<AudioEchoFilter> ();
		outputEchoFilter.delay = delay;
		outputEchoFilter.decayRatio = decayRatio;
		outputEchoFilter.dryMix = dryMix;
		outputEchoFilter.wetMix = wetMix;
		return spitObject;
	}

	public override void Feed (GameObject inputObject) {
		Debug.Log ("Feed EchoFilter");
		spitObject = inputObject;
	}
}
