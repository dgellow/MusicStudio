using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class OutputElement: MonoBehaviour {
	public List<ICanSendAudio> sources;
	public ICanReceiveAudio output;

	void Awake () {
		sources = new List<ICanSendAudio> ();
	}
}