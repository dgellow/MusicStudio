using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum MousePhase {
	Began,
	Ended,
	HoldDown
}

public class Utilities {
	public static Vector2 mousePositionWorld {
		get { return Camera.main.ScreenToWorldPoint (Input.mousePosition); }
	}

	public static bool CheckMouseClick(RectTransform rect, Camera camera, int mouseButtonId = 0, MousePhase phase = MousePhase.Began) {		
		var isInPhase = false;
		if (phase == MousePhase.Began) {
			isInPhase = Input.GetMouseButtonDown (mouseButtonId);
		} else if (phase == MousePhase.Ended) {
			isInPhase = Input.GetMouseButtonUp (mouseButtonId);
		} else if (phase == MousePhase.HoldDown) {
			isInPhase = Input.GetMouseButton (mouseButtonId);
		}
		return isInPhase && RectTransformUtility.RectangleContainsScreenPoint (rect, Input.mousePosition, camera);	
	}

	public static bool CheckTouch(RectTransform rect, Camera camera, TouchPhase phase = TouchPhase.Began) {
		return CheckTouches (rect, camera, phase).Count > 0;
	}

	public static bool CheckTouch(Collider2D collider, Camera camera, TouchPhase phase = TouchPhase.Began) {
		return CheckTouches (collider, camera, phase).Count > 0;
	}

	public static List<int> CheckTouches(RectTransform rect, Camera camera, TouchPhase phase)  {
		var touches = new List<int> ();
		if (Input.touchCount > 0) {
			foreach (var touch in Input.touches) {
				if (touch.phase == phase && RectTransformUtility.RectangleContainsScreenPoint (rect, touch.position, camera)) {
					touches.Add (touch.fingerId);
				}
			}
		}
		return touches;
	}

	public static List<int> CheckTouches(Collider2D collider, Camera camera, TouchPhase phase) {
		var touches = new List<int> ();
		if (Input.touchCount > 0) {
			foreach (var touch in Input.touches) {
				if (touch.phase == phase) {
					var worldPosition = camera.ScreenToWorldPoint (new Vector3 (touch.position.x, touch.position.y));
					if (collider.bounds.Contains (new Vector3 (worldPosition.x, worldPosition.y))) {
						touches.Add (touch.fingerId);
					}
				}
			}
		}
		return touches;
	}
}
