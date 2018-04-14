using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateCanvas : MonoBehaviour {
	private Text _scoreGUIText;	// El texto del score
	private Text _lifesGUIText;	// El textt de las vidas restantes
	private Text _bossLifesGUIText;	// El texto de las vidas restantes del boss

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (gameObject);

		// Inicializamos el texto de la GUI que marca la puntuación
		GameObject _scoreGUI = GameObject.FindGameObjectWithTag("ScoreText");
		if (_scoreGUI) {
			_scoreGUIText = _scoreGUI.GetComponent<Text> ();
			_scoreGUIText.text = "Score: " + PersistentData.Score;
		} else {
			Debug.LogWarning ("No hay ningún objeto con la etiquetas ScoreText. Por favor, comprueba que está asignada en el editor a el objeto correpondiente.");
		}

		// Inicializamos el texto de la GUI que marca las vidas restantes
		GameObject _lifesGUI = GameObject.FindGameObjectWithTag("LifesText");
		if (_lifesGUI) {
			_lifesGUIText = _lifesGUI.GetComponent<Text> ();
			_lifesGUIText.text = "Lifes: " + PersistentData.Lifes;
		} else {
			Debug.LogWarning ("No hay ningún objeto con la etiquetas LifesText. Por favor, comprueba que está asignada en el editor a el objeto correpondiente.");
		}
	}

	void Update(){
		UpdateScore ();
	}

	// Se llama desde el Detect By Contact
	public void UpdateScore(){
		if (_scoreGUIText) {
			// Actualizamos la puntuación en la GUI
			_scoreGUIText.text = "Score: " + PersistentData.Score;
		} else {
			Debug.LogWarning ("No hay ningún objeto con la etiquetas ScoreText. Por favor, comprueba que está asignada en el editor a el objeto correpondiente.");
		}

		if(_lifesGUIText){
			_lifesGUIText.text = "Lifes: " + PersistentData.Lifes;
		} else {
			Debug.LogWarning ("No hay ningún objeto con la etiquetas LifesText. Por favor, comprueba que está asignada en el editor a el objeto correpondiente.");
		}
	}
}
