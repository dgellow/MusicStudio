using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class ElementMenuEntry : MonoBehaviour {
	public UnityEvent onClick;
	public UnityEvent onMouseDown;

	Element element;

	void OnMouseDown() {
		onMouseDown.Invoke ();
	}

	void OnMouseUp() {		
		onClick.Invoke ();
	}
}
