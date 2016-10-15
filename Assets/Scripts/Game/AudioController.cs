using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AudioController : MonoBehaviour {
	public static void SendEvent(SourceElement sourceElement) {
		var sender = sourceElement.GetComponent<ICanSendAudio> ();
		FeedTargets (sender, sender.GetTargets());
	}

	static void FeedTargets(ICanSendAudio source, List<ICanReceiveAudio> targets) {
		foreach (var target in targets) {
			target.Feed (source.Spit ());	

			var nextSource = (target as MonoBehaviour).GetComponent<ICanSendAudio> ();
			if (nextSource != null) {
				FeedTargets (nextSource, nextSource.GetTargets ());
			}
		}
	}
}
