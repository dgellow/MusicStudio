using UnityEngine;
using System.Collections;

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
}

public interface ICanReceiveAudio {
	void Feed (GameObject sample);
}
