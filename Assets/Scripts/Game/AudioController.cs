using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AudioController : MonoBehaviour {

	public static void SendEvent(SourceElement sourceElement) {
		Debug.Log ("AudioController.SendEvent");
		Walkthrough (sourceElement);
	}

	static void Walkthrough (ICanReceiveAudio target) {
		var targetGameObject = target as MonoBehaviour;
		var intermediaryElement = targetGameObject.GetComponent<IntermediaryElement> ();
		var outputElement = targetGameObject.GetComponent<OutputElement> ();

		if (intermediaryElement != null) {
			Walkthrough (intermediaryElement);
		} else if (outputElement != null) {
			Walkthrough (outputElement);
		} else {
			throw new MissingComponentException ("Target should have a component IntermediaryElement or OutputElement");
		}
	}

	static void Walkthrough (SourceElement sourceElement) {
		foreach (var target in sourceElement.targets) {
			target.Feed (sourceElement.source.Spit ());
			Walkthrough (target);
		}
	}

	static void Walkthrough (IntermediaryElement element) {
		foreach (var source in element.sources) {
			foreach (var target in element.targets) {
				target.Feed (source.Spit ());
				Walkthrough (target);
			}
		}
	}

	static void Walkthrough (OutputElement outputElement) {
		foreach (var source in outputElement.sources) {
			outputElement.output.Feed (source.Spit ());
		}
	}
}
