using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AudioController : MonoBehaviour {

	public float sleepTime = 2f;

	void Start () {
		StartCoroutine (PlayLoop());
	}

	IEnumerator PlayLoop() {
		while (true) {
			Debug.Log ("Tick AudioManager.PlayLoop");
			var sourceElements = FindObjectsOfType<SourceElement> ();
			foreach (var sourceElement in sourceElements) {
				Walkthrough (sourceElement);
			}
			yield return new WaitForSeconds (sleepTime);
		}
	}

	void Walkthrough (SourceElement sourceElement) {
		foreach (var target in sourceElement.targets) {
			target.Feed (sourceElement.source.Spit ());

			var targetGameObject = target as MonoBehaviour;
			var intermediaryElement = targetGameObject.GetComponent<IntermediaryElement> ();
			var outputElement = targetGameObject.GetComponent<OutputElement> ();

			if (intermediaryElement != null) {
				Walkthrough (intermediaryElement);
			}

			if (outputElement != null) {
				Walkthrough (outputElement);
			}
		}
	}

	void Walkthrough (IntermediaryElement element) {
		foreach (var source in element.sources) {
			foreach (var target in element.targets) {
				target.Feed (source.Spit ());

				var targetGameObject = target as MonoBehaviour;
				var intermediaryElement = targetGameObject.GetComponent<IntermediaryElement> ();
				var outputElement = targetGameObject.GetComponent<OutputElement> ();

				if (intermediaryElement != null) {
					Walkthrough (intermediaryElement);
				}

				if (outputElement != null) {
					Walkthrough (outputElement);
				}
			}
		}
	}

	void Walkthrough (OutputElement outputElement) {
		foreach (var source in outputElement.sources) {
			outputElement.output.Feed (source.Spit ());
		}
	}
}
