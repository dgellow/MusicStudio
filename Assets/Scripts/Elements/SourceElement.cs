using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SourceElement: MonoBehaviour {
	public ICanSendAudio source;
	public List<ICanReceiveAudio> targets;
	public List<GameObject> targetObjects;

	void Awake() {
		source = GetComponent<ICanSendAudio> ();
		LoadTargets ();
	}

	void Update() {
		LoadTargets ();
	}

	void LoadTargets() {
		targets = new List<ICanReceiveAudio> ();
		foreach (var tObject in targetObjects) {
			if (tObject != null) {
				var target = tObject.GetComponent<ICanReceiveAudio> ();
				if (target != null) {
					targets.Add (target);
				} else {
					throw new MissingComponentException ("Target component doesn't implement the ICanReceiveAudio interface");
				}
			}
		}
	}
}