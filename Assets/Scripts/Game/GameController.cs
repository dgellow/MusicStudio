using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour {

	public static GameController gameState;
	public List<Board> boards;
	public int currentBoard;

	// Use this for initialization
	void Start () {
		if (gameState == null) {
			gameState = this;
			DontDestroyOnLoad (this);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
