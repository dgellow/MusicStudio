using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;

public class TabButton : MonoBehaviour {

	public Text text;
	public Image image;	
	public UnityEvent onClick;

	RectTransform rect;
	new Camera camera;

	void Start() {
		rect = GetComponent<RectTransform> ();
		camera = FindObjectOfType<Camera> ();
	}

	void FixedUpdate() {
		if (Utilities.CheckMouseClick (rect, camera) || Utilities.CheckTouch (rect, camera)) {
			onClick.Invoke ();
		}
	}
}
