using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SourceElement))]
public class PadLoop : MonoBehaviour, ICanSendAudio {

	public float sleepTime = 2f;
	public AudioClip sample;

	SourceElement sourceElement;

	void Start () {
		sourceElement = GetComponent<SourceElement> ();
		StartCoroutine (PlayLoop());
	}

	#region ICanSendAudio implementation

	public AudioClip Spit () {
		return sample;
	}

	#endregion

	IEnumerator PlayLoop() {
		while (true) {
			Debug.Log (string.Format("Tick PadLoop.PlayLoop #{0}", GetHashCode ()));			
			AudioController.SendEvent (sourceElement);
			yield return new WaitForSeconds (sleepTime);
		}
	}
}
