using UnityEngine;	
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class TabNavigation : MonoBehaviour {

	public List<TabButton> tabButtons;

	public Color selectedTextColor;
	public Color selectedColor;
	public Color defaultTextColor;
	public Color defaultColor;

	public Vector3 selectedPosition;
	public Vector3 defaultPosition;

	void OnGUI () {
		for (var i = 0; i < GameController.gameState.boards.Count; i++) {
			var button = tabButtons [i];
			var board = GameController.gameState.boards [i];
			if (i == GameController.gameState.currentBoard) {
				button.image.color = selectedColor;
				button.text.color = selectedTextColor;
				board.rect.anchoredPosition = selectedPosition;
			} else {
				button.image.color = defaultColor;
				button.text.color = defaultTextColor;
				board.rect.anchoredPosition = defaultPosition;
			}
		}
	}

	public void SelectTab (int tabId) {
		GameController.gameState.currentBoard = tabId;
	}
}
