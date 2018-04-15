using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateCanvas : MonoBehaviour {
	private Text _scoreGUIText;	// El texto del score
	private Text _lifesGUIText;	// El textt de las vidas restantes
	private Text _bossLifesGUIText;	// El texto de las vidas restantes del boss
	private GameObject _pauseButton;	// El botón del menú de pausa

	private string _warningMessage = "Por favor, comprueba que la siguiente etiqueta está asignada en el editor al objeto correpondiente: ";

	private bool _gamePaused = false;

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (gameObject);

		// Inicializamos el texto de la GUI que marca la puntuación
		GameObject _scoreGUI = GameObject.FindGameObjectWithTag("ScoreText");
		if (_scoreGUI) {
			_scoreGUIText = _scoreGUI.GetComponent<Text> ();
			_scoreGUIText.text = "Score: " + PersistentData.Score;
		} else {
			Debug.LogWarning (_warningMessage + "ScoreText");
		}

		// Inicializamos el texto de la GUI que marca las vidas restantes del jugador
		GameObject _lifesGUI = GameObject.FindGameObjectWithTag("LifesText");
		if (_lifesGUI) {
			_lifesGUIText = _lifesGUI.GetComponent<Text> ();
			_lifesGUIText.text = "Lifes: " + PersistentData.Lifes;
		} else {
			Debug.LogWarning (_warningMessage + "LifesText");
		}

		// Inicializamos el texto de la GUI que marca las vidas restantes del boss
		GameObject _bossLifesGUI = GameObject.FindGameObjectWithTag("BossLifesText");
		if (_bossLifesGUI) {
			_bossLifesGUIText = _bossLifesGUI.GetComponent<Text> ();
			_bossLifesGUIText.text = "Boss lifes: " + PersistentData.BossLifes;
		} else {
			// Para que este aviso solo pueda salir en el nivel final
			if (PersistentData.IsThirdLevelLoaded) {
				Debug.LogWarning (_warningMessage + "BossLifesText");
			}
		}

		_pauseButton = GameObject.FindGameObjectWithTag ("PauseButton");
		if (_pauseButton != null) {
			_pauseButton.SetActive (false);
		}
	}

	void Update(){
		UpdateScore ();

		// Pausa el juego si pulsamos la barra espaciadora
		if (Input.GetKeyDown (KeyCode.Space) && !_gamePaused) {
			if (!_gamePaused) {
				Time.timeScale = 0;
				if (_pauseButton != null) {
					_pauseButton.SetActive (true);
				}
				_gamePaused = true;
			}
		}

		// Si morimos o ganamos, desactivamos el canvas para que no se vea
		if (PersistentData.IsGameOverScreenLoaded || PersistentData.IsWinScreenLoaded) {
			gameObject.SetActive (false);
		}
	}

	// Se llama desde el Detect By Contact
	public void UpdateScore(){
		if (_scoreGUIText) {
			// Actualizamos la puntuación en la GUI
			_scoreGUIText.text = "Score: " + PersistentData.Score;
		} else {
			Debug.LogWarning (_warningMessage + "ScoreText");
		}

		if(_lifesGUIText){
			_lifesGUIText.text = "Lifes: " + PersistentData.Lifes;
		} else {
			Debug.LogWarning (_warningMessage + "LifesText");
		}

		if (_bossLifesGUIText) {
			// Actualizamos la puntuación en la GUI
			_bossLifesGUIText.text = "Boss lifes: " + PersistentData.BossLifes;
		} else {
			if (PersistentData.IsThirdLevelLoaded) {
				Debug.LogWarning (_warningMessage + "BossLifesText");
			}
		}
	}

	public void ResumeGame(){
		Time.timeScale = 1;
		if (_pauseButton != null) {
			_pauseButton.SetActive (false);
		}
		_gamePaused = false;
	}
}
