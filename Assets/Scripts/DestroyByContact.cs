using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DestroyByContact : MonoBehaviour {
	public AudioClip PunchedClip, PlayerKilledClip;	// El sonido al ser golpeado

	private Text _scoreGUI;	// El texto del score

	void Start(){
		// Inicializamos el texto de la GUI que marca la puntuación
		_scoreGUI = GameObject.FindGameObjectWithTag("ScoreText").GetComponent<Text>();
		_scoreGUI.text = "Score: " + PersistentData.Score;
	}

	void OnTriggerStay2D(Collider2D col){
		if (col.gameObject.layer == Layers.Boundary) {
			// Si el enemigo está dentro del límite de juego, no se destruye (:V)
			return;
		} else if(col.gameObject.layer == Layers.Player && PlayerMovement.isAtacking()){
			AudioSource.PlayClipAtPoint(PunchedClip, transform.position);

			// Si estamos atacando y chocamos con el enemigo, el enemigo muere
			PersistentData.Score++;

			// Actualizamos la puntuación en la GUI
			_scoreGUI.text = "Score: " + PersistentData.Score;

			Destroy (gameObject);
		} else if (col.gameObject.layer == Layers.Player && !PlayerMovement.isAtacking()) {
			// Si NO estamos atacando y chocamos con el enemigo, morimos nosotros
			// TODO GameOver (poner explosion o algo)
			AudioSource.PlayClipAtPoint(PlayerKilledClip, col.gameObject.transform.position);
			PersistentData._isPlayerDead = true;
		}
	}
}
