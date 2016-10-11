using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public enum GeneratorDragPhase {
	Begin,
	OverScrollView,
	OverBoard,
	EndOverBoard,
	Cancel
}

public class GameController : MonoBehaviour {

	public static GameController gameState;
	public List<Board> boards;
	public int currentBoard;

	GameObject generatorDragMarker;
	[SerializeField]
	GeneratorDragPhase generatorDragPhase;

	void Awake () {
		if (gameState == null) {
			gameState = this;
			DontDestroyOnLoad (this);
		}
	}

	public void GeneratorBeginDrag (string prefabPath) {
		Destroy (generatorDragMarker);
		generatorDragMarker = Instantiate (Resources.Load (prefabPath) as GameObject);
		generatorDragMarker.transform.localScale = new Vector3 (1, 1, 1);
		generatorDragMarker.transform.position = new Vector3(Utilities.mousePositionWorld.x, Utilities.mousePositionWorld.y, -2);
		generatorDragPhase = GeneratorDragPhase.Begin;
	}

	public void GeneratorDragOverScrollView (string prefabPath) {
		if (generatorDragPhase != GeneratorDragPhase.OverScrollView) {
			Destroy (generatorDragMarker);
			generatorDragMarker = Instantiate (Resources.Load (prefabPath) as GameObject);
		}
		generatorDragMarker.transform.localScale = new Vector3 (1, 1, 1);
		generatorDragMarker.transform.position = new Vector3(Utilities.mousePositionWorld.x, Utilities.mousePositionWorld.y, -2);
		generatorDragPhase = GeneratorDragPhase.OverScrollView;
	}

	public void GeneratorDragOverBoard (string prefabPath) {
		if (generatorDragPhase != GeneratorDragPhase.OverBoard) {
			Destroy (generatorDragMarker);
			generatorDragMarker = Instantiate (Resources.Load (prefabPath) as GameObject);
		}
		generatorDragMarker.transform.localScale = new Vector3 (1, 1, 1);
		generatorDragMarker.transform.position = new Vector3(Utilities.mousePositionWorld.x, Utilities.mousePositionWorld.y, -2);
		generatorDragPhase = GeneratorDragPhase.OverBoard;
	}

	public void GeneratorDragEndOnBoard (string prefabPath) {
		var board = boards [currentBoard];
		var prefabToClone = (Resources.Load (prefabPath) as GameObject).GetComponent<Element> ();
		if (prefabToClone == null) {
			throw new MissingComponentException ("Prefab should have Element component");
		}
		Destroy (generatorDragMarker);
		var prefab = Instantiate (prefabToClone);
		prefab.transform.parent = board.transform;
		prefab.transform.localScale = new Vector3 (100, 100, 100);
		var localPoint = new Vector2();
		if (RectTransformUtility.ScreenPointToLocalPointInRectangle (board.rect, new Vector2 (Input.mousePosition.x, Input.mousePosition.y), Camera.main, out localPoint)) {
			prefab.transform.localPosition = new Vector3(localPoint.x, localPoint.y, -10);
		} else {
			throw new UnityException ("Shouldn't happen. If it does I have no idea why");
		}

		generatorDragMarker = null;
		generatorDragPhase = GeneratorDragPhase.EndOverBoard;
	}

	public void GeneratorDragCancel () {
		Destroy (generatorDragMarker);
		generatorDragMarker = null;
		generatorDragPhase = GeneratorDragPhase.Cancel;
	}
}
