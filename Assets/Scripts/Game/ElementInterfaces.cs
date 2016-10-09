using UnityEngine;
using System.Collections;

public interface IPlayableElement {
	IEnumerator Play ();
}

public interface ILoopableElement {
	void Start ();
	void Stop ();
	void Pause ();
}