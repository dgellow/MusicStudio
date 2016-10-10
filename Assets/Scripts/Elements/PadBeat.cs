using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SourceElement))]
public class PadBeat : MonoBehaviour, ICanSendAudio {

	public AudioClip sample;
	public ICanReceiveAudio linkTarget;

	SourceElement sourceElement;
	new Collider2D collider;
	new Camera camera;

	void Start () {
		collider = GetComponent<CircleCollider2D> ();
		camera = FindObjectOfType<Camera> ();
		sourceElement = GetComponent<SourceElement> ();
	}
	
	void FixedUpdate() {
		if (Utilities.CheckTouch (collider, camera)) {
			AudioController.SendEvent (sourceElement);
		}
	}

	void OnMouseDown() {
		AudioController.SendEvent (sourceElement);
	}

	#region ICanSendAudio implementation

	public AudioClip Spit () {
		return sample;
	}

	#endregion
}
