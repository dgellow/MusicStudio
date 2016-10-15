using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class SourceElement: Element, ICanSendAudio {
	public ICanSendAudio source;
	// public List<ICanReceiveAudio> targets;
	public List<Element> targetElements;

	void Awake() {
		source = GetComponent<ICanSendAudio> ();
		// LoadTargets ();
	}

//	void Update() {
//		LoadTargets ();
//	}

//	void LoadTargets() {
//		targets = new List<ICanReceiveAudio> ();
//		foreach (var tObject in targetElements) {
//			if (tObject != null) {
//				var target = tObject.GetComponent<ICanReceiveAudio> ();
//				if (target != null) {
//					targets.Add (target);
//				} else {
//					throw new MissingComponentException ("Target component doesn't implement the ICanReceiveAudio interface");
//				}
//			}
//		}
//	}

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