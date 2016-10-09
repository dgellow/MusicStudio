using UnityEngine;
using System.Collections;

public class DebugCamera : MonoBehaviour {

	public GameObject touchMarker;
	public bool isDebugging = true;

	Vector2 touchPosition;
	GameObject[] touchMarkers;
	Camera camera;

	// Use this for initialization
	void Start () {
		camera = GetComponent<Camera> ();
		touchMarkers = new GameObject[10];
	}

	void FixedUpdate() {
		if (isDebugging) {
			if (Input.touchCount > 0) {
				foreach (var touch in Input.touches) {
					var worldPosition = camera.ScreenToWorldPoint (new Vector3 (touch.position.x, touch.position.y));
					if (touch.phase == TouchPhase.Began) {
						touchMarkers [touch.fingerId] = Instantiate (touchMarker);
						touchMarkers [touch.fingerId].transform.position = new Vector3 (worldPosition.x, worldPosition.y);
					} else if (touch.phase == TouchPhase.Moved) {
						touchMarkers [touch.fingerId].transform.position = new Vector3 (worldPosition.x, worldPosition.y);
					} else if (touch.phase != TouchPhase.Stationary) {
						Destroy (touchMarkers [touch.fingerId]);
					}
				}
			}
		}
	}
}
