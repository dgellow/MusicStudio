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
	AudioClip Spit();
}

public interface ICanReceiveAudio {
	void Feed (AudioClip sample);
}
