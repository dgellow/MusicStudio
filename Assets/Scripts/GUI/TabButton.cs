using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;

public class TabButton : MonoBehaviour {

	public Text text;
	public Image image;	
	public UnityEvent onClick;

	RectTransform rect;

	void Start() {
		rect = GetComponent<RectTransform> ();
	}

	void FixedUpdate() {
		if (Utilities.CheckMouseClick (rect) || Utilities.CheckTouch (rect)) {
			onClick.Invoke ();
		}
	}
}
