using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour {
	private Canvas _pauseCanvas;
	private bool _gamePaused = false;

	void Start(){
		DontDestroyOnLoad (gameObject);
		_pauseCanvas = GetComponent<Canvas> ();
		_pauseCanvas.enabled = false;
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space) && !_gamePaused) {
			if (!_gamePaused) {
				Time.timeScale = 0;
				_pauseCanvas.enabled = true;
				_gamePaused = true;
			}
		}
	}

	public void ResumeGame(){
		Time.timeScale = 1;
		_pauseCanvas.enabled = false;
		_gamePaused = false;
	}
}
