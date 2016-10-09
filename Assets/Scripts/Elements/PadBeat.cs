using UnityEngine;
using System.Collections;

public class PadBeat : MonoBehaviour {

	public AudioClip audioClip;
	public OutputAudio output;

	Collider2D collider;
	Camera camera;

	// Use this for initialization
	void Start () {
		collider = GetComponent<CircleCollider2D> ();
		camera = FindObjectOfType<Camera> ();
	}
	
	void FixedUpdate() {
		if (Input.touchCount > 0) {
			foreach (var touch in Input.touches) {
				if (touch.phase == TouchPhase.Began) {
					var worldPosition = camera.ScreenToWorldPoint (new Vector3 (touch.position.x, touch.position.y));
					if (collider.bounds.Contains (new Vector3 (worldPosition.x, worldPosition.y))) {
						Play ();
					}
				}
			}
		}
	}

	void Play() {
		var audioSource = output.GetComponent<AudioSource> ();
		audioSource.PlayOneShot (audioClip);
	}
}
