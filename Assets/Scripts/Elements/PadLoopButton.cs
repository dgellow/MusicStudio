using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class PadLoopButton : MonoBehaviour {
	public UnityEvent onClick;

	#if UNITY_IOS

	Collider2D collider;

	void Awake() {
		collider = GetComponent<Collider2D> ();
	}
		
	void Update() {
		if (Utilities.CheckTouch (collider, Camera.main)) {
			onClick.Invoke ();
		}
	}

	#endif

	#if UNITY_EDITOR

	void OnMouseDown() {
	    onClick.Invoke ();
	}

	#endif
}
