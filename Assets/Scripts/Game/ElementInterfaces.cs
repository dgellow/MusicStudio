using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public interface IPlayableElement {
	void PlaySample ();
}

public interface ILoopableElement {
	void StartLoop ();
	void StopLoop ();
	void PauseLoop ();
}

public interface ICanSendAudio {
	GameObject Spit();
	List<ICanReceiveAudio> GetTargets ();
}

public interface ICanReceiveAudio {
	void Feed (GameObject sample);
}

