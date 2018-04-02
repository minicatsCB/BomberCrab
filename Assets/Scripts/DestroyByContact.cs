using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour {
	public AudioClip PunchedClip, PlayerKilledClip;	// El sonido al ser golpeado
	public int BossLifes = 10;	// La vida que le tengo que quitar al jefe para matarlo

	private GameObject _scoreCanvas;
	private UpdateCanvas _canvasUpdater;	// Para actualizar la puntación mostrada en el canvas

	void Start(){
		BossLifes = 10;
		_scoreCanvas = GameObject.FindGameObjectWithTag ("ScoreCanvas");
		_canvasUpdater = _scoreCanvas.GetComponent<UpdateCanvas> ();
	}

	void OnTriggerEnter2D(Collider2D col){
		if(col.gameObject.layer == Layers.Player && PlayerMovement.isAtacking()){
			AudioSource.PlayClipAtPoint(PunchedClip, transform.position);

			// Si estamos atacando y chocamos con el enemigo, el enemigo muere
			PersistentData.Score++;

			// Actualizamos los datos mostrados en el canvas
			_canvasUpdater.UpdateScore ();

			// Si estoy atacando al jefe, necesito quitarle más vidas que al resto de enemigos para matarlo
			if (gameObject.tag == "Boss") {
				/*if (BossLifes > 0) {
					Debug.Break ();
					BossLifes--;
				} else {
					Destroy (gameObject);
				}*/
			} else {
				Destroy (gameObject);
			}
		} else if (col.gameObject.layer == Layers.Player && !PlayerMovement.isAtacking()) {
			// Si NO estamos atacando y chocamos con el enemigo, morimos nosotros
			// TODO GameOver (poner explosion o algo)
			PersistentData.Lifes--;
			_canvasUpdater.UpdateScore ();
			AudioSource.PlayClipAtPoint(PlayerKilledClip, col.gameObject.transform.position);

			Debug.Log ("Vida: " + PersistentData.Lifes);
			if (PersistentData.Lifes <= 0) {
				PersistentData._isPlayerDead = true;
			}
		}
	}
}
