using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SourceElement))]
public class PadBeat : MonoBehaviour, ICanSendAudio {

	public AudioClip sample;
	public ICanReceiveAudio linkTarget;
	public SourceElement sourceElement;

	Collider2D collider = new Collider2D();
	Camera camera = new Camera();

	// Use this for initialization
	void Start () {
		collider = GetComponent<CircleCollider2D> ();
		camera = FindObjectOfType<Camera> ();
		//sourceElement = GetComponent<SourceElement> ();
	}
	
//	void FixedUpdate() {
//		var touchesBegan = Utilities.CheckTouches (collider, camera, TouchPhase.Began);
//		foreach (var _ in touchesBegan) {
//			PlaySample();
//		}
//	}

	#region ICanSendAudio implementation

	public AudioClip Spit () {
		return sample;
	}

	#endregion
}
