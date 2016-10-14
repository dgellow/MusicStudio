using UnityEngine;
using System.Collections;

public enum LoopState {
	Play,
	Pause,
	Stop
}

[RequireComponent(typeof(SourceElement))]
public class PadLoop : MonoBehaviour, ICanSendAudio {

	public float sleepTime = 2f;
	public AudioClip sample;
	public LoopState loopState = LoopState.Stop;
	public SpriteRenderer buttonPlaySprite;
	public SpriteRenderer buttonPauseSprite;
	public SpriteRenderer buttonStopSprite;
	public Color buttonDisableColor;
	public Color buttonDefaultColor;
	public TextMesh loopSleepText;

	SourceElement sourceElement;
	Coroutine innerLoop;

	void Start () {
		sourceElement = GetComponent<SourceElement> ();
	}

	void OnGUI() {
		buttonPlaySprite.color = buttonDefaultColor;
		buttonPauseSprite.color = buttonDefaultColor;
		buttonStopSprite.color = buttonDefaultColor;

		if (loopState == LoopState.Play) {
			buttonPlaySprite.color = buttonDisableColor;
		} else if (loopState == LoopState.Pause) {
			buttonPauseSprite.color = buttonDisableColor;
		} else if (loopState == LoopState.Stop) {
			buttonPauseSprite.color = buttonDisableColor;
			buttonStopSprite.color = buttonDisableColor;
		}

		loopSleepText.text = string.Format ("{0}s", sleepTime);
	}

	void Update() {
		if (innerLoop == null && loopState == LoopState.Play) {
			innerLoop = StartCoroutine (PlayInnerLoop ());
		} else if (innerLoop != null && loopState == LoopState.Stop) {
			StopCoroutine (innerLoop);
			innerLoop = null;
		}
	}

	#region ICanSendAudio implementation

	public GameObject Spit () {
		return sample;
	}

	#endregion

	public void SetLoopStatePlay() {
		loopState = LoopState.Play;
	}

	public void SetLoopStatePause() {
		loopState = LoopState.Pause;
	}

	public void SetLoopStateStop() {
		loopState = LoopState.Stop;
	}

	IEnumerator PlayInnerLoop() {
		while (loopState != LoopState.Stop) {
			Debug.Log (string.Format("Tick PadLoop.PlayLoop #{0}", GetHashCode ()));
			if (loopState == LoopState.Pause) {
				yield return new WaitWhile (() => loopState == LoopState.Pause);
			} else if (loopState == LoopState.Play) {
				AudioController.SendEvent (sourceElement);
				yield return new WaitForSeconds (sleepTime);	
			}
		}
	}
}
