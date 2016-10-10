using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SourceElement))]
public class PadBeat : MonoBehaviour, ICanSendAudio {

	public AudioClip sample;
	public ICanReceiveAudio linkTarget;

	SourceElement sourceElement;
	Collider2D collider = new Collider2D();
	Camera camera = new Camera();

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
