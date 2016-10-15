using UnityEngine;
using System.Collections;

public class PadBeatMenu : MonoBehaviour {

	public Collider2D colliderEntryRecord;
	PadBeat padBeat;

	void Start () {
		padBeat = GetComponentInParent<PadBeat> ();
	}

	public void SelectEntrySample () {
		Debug.Log ("Select menu entry \"PadBeat > Sample\"");
	}

	public void SelectEntryRecord () {
		Debug.Log ("Select menu entry \"PadBeat > Record\"");
		StartCoroutine (RecordMicrophone ());
	}

	IEnumerator RecordMicrophone () {
		Debug.Log ("Start recording");
		var clip = Microphone.Start (null, false, 10, 44100);
		while (Microphone.IsRecording (null) &&
		       (Utilities.CheckTouch (colliderEntryRecord, TouchPhase.Began) ||
		       Utilities.CheckTouch (colliderEntryRecord, TouchPhase.Moved) ||
		       Utilities.CheckTouch (colliderEntryRecord, TouchPhase.Stationary))) {
			yield return new WaitForEndOfFrame ();
		}
		Debug.Log ("Stop recording");
		Microphone.End (null);
		padBeat.sample = clip;
	}

	public void SelectEntryRelationships () {
		Debug.Log ("Select menu entry \"PadBeat > Relationships\"");
	}

	public void SelectEntryShape () {
		Debug.Log ("Select menu entry \"PadBeat > Shape\"");
	}

	public void SelectEntryMove () {
		Debug.Log ("Select menu entry \"PadBeat > Move\"");
	}
}
