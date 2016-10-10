using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Events;

public class ElementGenerator : MonoBehaviour {

	public GameObject prefab;
	public UnityEvent onDragOverScrollView;
	public UnityEvent onDragOverBoard;
	public UnityEvent onDragEndOverBoard;
	public UnityEvent onDragEndSomewhereElse;

	GameObject instance;
	RectTransform rectTransform;
	RectTransform parentRectTransform;
	Camera camera;
	Text text;

	void Start() {
		rectTransform = GetComponent<RectTransform> ();
		camera = FindObjectOfType<Camera> ();
		text = GetComponentInChildren<Text> ();
		parentRectTransform = transform.parent.GetComponent<RectTransform> ();
	}

//	void FixedUpdate () {
//		var mouseWorldPosition = camera.ScreenToWorldPoint (new Vector3(Input.mousePosition.x, Input.mousePosition.y));
//		if (Input.GetMouseButtonDown (0) && RectTransformUtility.RectangleContainsScreenPoint (rectTransform, Input.mousePosition, camera)) {
//			Debug.Log ("Click on " + text.text);
//			instance = Instantiate (prefab);
//			instance.transform.position = new Vector3(mouseWorldPosition.x, mouseWorldPosition.y, 0);
//		}
//
//		if (Input.GetMouseButton (0) && instance != null) {
//			instance.transform.position = new Vector3 (mouseWorldPosition.x, mouseWorldPosition.y, 0);
//		}
//
//		if (Input.GetMouseButtonUp (0) && instance != null) {
//			if (RectTransformUtility.RectangleContainsScreenPoint (parentRectTransform, Input.mousePosition, camera)) {
//				instance.transform.position = new Vector3 (mouseWorldPosition.x, mouseWorldPosition.y, 0);
//				instance = null;
//			}
//		}
//
////		if (Input.touchCount > 0) {
////			foreach (var touch in Input.touches) {
////				var worldPosition = camera.ScreenToWorldPoint (new Vector3(touch.position.x, touch.position.y));
////				if (RectTransformUtility.RectangleContainsScreenPoint (rectTransform, touch.position) && 
////					touch.phase == TouchPhase.Began) {
////					instances [touch.fingerId] = Instantiate (prefab);
////					instances [touch.fingerId].transform.position = worldPosition; 
////				} else if (instances [touch.fingerId] != null && touch.phase == TouchPhase.Moved) {
////					instances [touch.fingerId].transform.position = worldPosition;
////				} else if (touch.phase == TouchPhase.Canceled || touch.phase == TouchPhase.Ended) {
////					Destroy (instances [touch.fingerId]);
////				}
////			}
////		}
//	}
}
