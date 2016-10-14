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
		} else {
			throw new MissingComponentException ("Target should have a component IntermediaryElement");
		}
	}

	static void Walkthrough (SourceElement sourceElement) {
		foreach (var target in sourceElement.targets) {	
			target.Feed (sourceElement.source.Spit ());
			Walkthrough (target);
		}
	}

	static void Walkthrough (IntermediaryElement element) {
		var sender = element.GetComponent<ICanSendAudio> ();
		foreach (var target in element.targets) {
			target.Feed (sender.Spit ());
		}
	}
}
