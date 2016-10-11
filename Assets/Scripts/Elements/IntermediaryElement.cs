using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class IntermediaryElement: MonoBehaviour {
	public List<ICanSendAudio> sources;
	public List<ICanReceiveAudio> targets;
	public List<Element> targetElements;

	void Awake() {
		LoadTargets ();
		LoadSources ();
	}

	void Update() {
		LoadTargets ();
		LoadSources ();
	}

	void LoadSources() {
		var board = GameController.gameState.boards [GameController.gameState.currentBoard];
		sources = new List<ICanSendAudio> ();
		foreach (var sender in board.GetComponentsInChildren<ICanSendAudio> ()) {
			var sourceGameObject = sender as MonoBehaviour;
			var sourceElement = sourceGameObject.GetComponent<SourceElement> ();
			var intermediaryElement = sourceGameObject.GetComponent<IntermediaryElement> ();

			if ((sourceElement != null && sourceElement.targetElements.Contains (GetComponent<Element> ())) || 
				(intermediaryElement != null && intermediaryElement.targetElements.Contains (GetComponent<Element> ()))) {
				sources.Add (sender);
			}
		}
	}

	void LoadTargets() {
		targets = new List<ICanReceiveAudio> ();
		foreach (var tObject in targetElements) {
			var target = tObject.GetComponent<ICanReceiveAudio> ();
			if (target != null) {
				targets.Add (target);
			} else {
				throw new MissingComponentException ("Target component doesn't implement the ICanReceiveAudio interface");
			}
		}
	}
}