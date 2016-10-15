using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum ElementTouchPhase {
	None,
	Began,
	Tap,
	LongPressed,
	Canceled
}
	
public class PadBeat : SourceElement {

	public AudioClip sample;
	public ICanReceiveAudio linkTarget;
	public bool showMenu = false;

	ElementMenu menu;
	SourceElement sourceElement;
	new Collider2D collider;

	[SerializeField]
	ElementTouchPhase touchPhase;
	[SerializeField]
	float touchDuration = 0f;

	void Awake () {
		collider = GetComponent<CircleCollider2D> ();
		sourceElement = GetComponent<SourceElement> ();
		menu = GetComponentInChildren<ElementMenu> ();
	}

	void Update() {
		menu.gameObject.SetActive (showMenu);
	}

	void FixedUpdate() {
		if (touchPhase == ElementTouchPhase.Began) {
			touchDuration += Time.fixedDeltaTime;

			// Long press
			if (!showMenu && touchDuration >= GameController.gameState.settings.elementMenuTouchDuration) {
				Debug.Log ("Long press");
				showMenu = true;
				touchPhase = ElementTouchPhase.LongPressed;
			} 

			// Tap
			else if (Input.touchCount == 0 || (touchDuration < GameController.gameState.settings.elementMenuTouchDuration && Utilities.CheckTouch (collider, TouchPhase.Ended))) {
				Debug.Log ("Tap");
				touchPhase = ElementTouchPhase.Tap;
				touchDuration = 0f;

				if (showMenu) {
					showMenu = false;
				} else {
					Debug.Log ("Send event");
					AudioController.SendEvent (sourceElement);
				}
			}

			// Canceling
			else if (Input.touches[0].phase != TouchPhase.Began && !Utilities.CheckTouch (collider, TouchPhase.Stationary) && !Utilities.CheckTouch (collider, TouchPhase.Moved)) {
				touchPhase = ElementTouchPhase.Canceled;
				showMenu = false;	
				touchDuration = 0;
			}
		} else if (Utilities.CheckTouch (collider, TouchPhase.Began)) {
			touchPhase = ElementTouchPhase.Began;
		}
	}

	void OnMouseDown() {
		AudioController.SendEvent (sourceElement);
	}

	public override GameObject Spit () {
		Debug.Log ("Spit PadBeat");
		var spitObject = new GameObject ();
		var audioSource = spitObject.AddComponent<AudioSource> ();
		audioSource.clip = sample;
		return spitObject;
	}
}
