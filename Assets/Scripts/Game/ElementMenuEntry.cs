using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class ElementMenuEntry : MonoBehaviour {
	public UnityEvent onClick;

	Element element;

	void OnMouseUp() {		
		onClick.Invoke ();
	}
}
