using UnityEngine;
using System.Collections;

[RequireComponent(typeof(IntermediaryElement))]
public class DistortionFilter : MonoBehaviour, ICanSendAudio, ICanReceiveAudio {

	public float distortionLevel;
	public GameObject spitContent;

	GameObject inputObject;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	#region ICanSendAudio implementation

	public GameObject Spit () {
		inputObject.AddComponent<AudioDistortionFilter> ();
		var outputDistortionFilter = inputObject.GetComponent<AudioDistortionFilter> ();
		outputDistortionFilter.distortionLevel = distortionLevel;
		return inputObject;
	}

	#endregion

	#region ICanReceiveAudio implementation

	public void Feed (GameObject inputObject) {
		this.inputObject = inputObject;
	}

	#endregion
}
