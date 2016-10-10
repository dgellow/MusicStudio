using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Events;

public class ElementGenerator : MonoBehaviour {

	public GameObject prefab;
	public UnityEvent onDragBegin;
	public UnityEvent onDragOverScrollView;
	public UnityEvent onDragOverBoard;
	public UnityEvent onDragEndOverBoard;
	public UnityEvent onDragEndSomewhereElse;
	public RectTransform rectScrollView;

	GameObject instance;
	RectTransform rect;
	new Camera camera;

	bool dragBegan = false;

	void Start() {
		rect = GetComponent<RectTransform> ();
		camera = FindObjectOfType<Camera> ();
	}

	void FixedUpdate() {
		var rectBoard = GameController.gameState.boards [GameController.gameState.currentBoard].rect;

		if (Utilities.CheckMouseClick (rect, camera, 0, MousePhase.Began)) {
			dragBegan = true;
			onDragBegin.Invoke ();
		} else if (dragBegan) {
			if (Utilities.CheckMouseClick (rectScrollView, camera, 0, MousePhase.HoldDown)) {
				onDragOverScrollView.Invoke ();
			} else if (Utilities.CheckMouseClick (rectBoard, camera, 0, MousePhase.HoldDown)) {
				onDragOverBoard.Invoke ();
			} else if (Utilities.CheckMouseClick (rectBoard, camera, 0, MousePhase.Ended)) {
				dragBegan = false;
				onDragEndOverBoard.Invoke ();
			} else if (Input.GetMouseButtonUp (0)) {
				dragBegan = false;
				onDragEndSomewhereElse.Invoke ();
			}	
		}
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
