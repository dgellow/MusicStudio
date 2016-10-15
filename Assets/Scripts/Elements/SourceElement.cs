using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class SourceElement: Element, ICanSendAudio {
	public ICanSendAudio source;
	public List<Element> targetElements;

	SpriteRenderer renderer;

	void Awake() {
		source = GetComponent<ICanSendAudio> ();
	}
		
	void Start() {
		renderer = GetComponent<SpriteRenderer> ();
	}

	void Update() {
		if (GameController.gameState.phase == GamePhase.LivePlay) {
			LivePlayUpdate ();
		} else if (GameController.gameState.phase == GamePhase.RelationshipSelection) {
			RelationshipSelectionUpdate ();
		}
	}

	void LivePlayUpdate() {
		renderer.material.color = new Color (
			renderer.material.color.r, 
			renderer.material.color.g,
			renderer.material.color.b,
			1f
		);
	}

	void RelationshipSelectionUpdate() {
		renderer.material.color = new Color (
			renderer.material.color.r, 
			renderer.material.color.g,
			renderer.material.color.b,
			.1f
		);
	}

	#region ICanSendAudio implementation

	public virtual GameObject Spit () {
		throw new System.NotImplementedException ("Should be overriden in child class");
	}

	public virtual List<ICanReceiveAudio> GetTargets () {
		var targets = targetElements.Select (x => x.GetComponent<ICanReceiveAudio> ()).Where (x => x != null).ToList ();
		return targets;
	}

	#endregion
}