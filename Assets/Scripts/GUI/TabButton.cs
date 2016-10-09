using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;

public class TabButton : MonoBehaviour {

	public Text text;
	public Image image;	
	public UnityEvent onClick;

	RectTransform rect;
	Camera camera;

	void Start() {
		rect = GetComponent<RectTransform> ();
		camera = FindObjectOfType<Camera> ();
	}

	void FixedUpdate() {
		if (CheckClickOrTouch ()) {
			onClick.Invoke ();
		}
	}

	bool CheckClickOrTouch() {
		var hasBeenClick = Input.GetMouseButtonDown (0) && RectTransformUtility.RectangleContainsScreenPoint (rect, Input.mousePosition, camera);
		var hasBeenTouched = false;

		if (Input.touchCount > 0) {
			foreach(var touch in Input.touches) {
				if (touch.phase == TouchPhase.Began && RectTransformUtility.RectangleContainsScreenPoint (rect, touch.position, camera)) {
					hasBeenTouched = true;
					break;
				}
			}
		}

		return hasBeenClick || hasBeenTouched;
	}
}
