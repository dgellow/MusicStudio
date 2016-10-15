using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class OutputElement: Element, ICanReceiveAudio {
	public List<ICanSendAudio> sources;
	public ICanReceiveAudio output;

	void Awake () {
		sources = new List<ICanSendAudio> ();
	}

	#region ICanReceiveAudio implementation

	public virtual void Feed (GameObject sample) {
		throw new System.NotImplementedException ("Should be overriden in child class");
	}

	#endregion
}