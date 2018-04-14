using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour {
	public AudioClip PunchedClip, PlayerKilledClip;	// El sonido al ser golpeado
	public int BossLifes = 10;	// La vida que le tengo que quitar al jefe para matarlo

	private GameObject _scoreCanvas;
	private Color _originalBossColor;
	private Color _originalPlayerColor;

	void Start(){
		BossLifes = 3;
		_originalBossColor = GetComponent<SpriteRenderer> ().color;
	}

	void Update(){
		if (BossLifes == 0) {
			GameObject go = GameObject.FindGameObjectWithTag ("Boss");
			if (go != null) {
				Destroy (go);
				PersistentData.IsBossDead = true;
			}
		}
	}

	void OnTriggerEnter2D(Collider2D col){
		if(col.gameObject.layer == Layers.Player && PlayerMovement.isAtacking()){
			AudioSource.PlayClipAtPoint(PunchedClip, transform.position);
			Debug.Log ("Jugador golpeó y alcanzó");

			// Si estamos atacando y chocamos con el enemigo, el enemigo muere
			PersistentData.Score++;

			// Si estoy atacando al jefe, necesito quitarle más vidas que al resto de enemigos para matarlo
			if (gameObject.tag == "Boss") {
				BossLifes--;
				iTween.ColorTo (gameObject, Color.red, 1);
				Debug.Log ("BOSS lifes: " + BossLifes);
			} else {
				// El resto de enemigos se destruyen al primer ataque
				Destroy (gameObject);
			}
		} else if (col.gameObject.layer == Layers.Player && !PlayerMovement.isAtacking()) {
			// Si NO estamos atacando y chocamos con el enemigo, morimos nosotros
			PersistentData.Lifes--;
			AudioSource.PlayClipAtPoint(PlayerKilledClip, col.gameObject.transform.position);
			Debug.Log ("Jugador FUE golpeado y alcanzado");

			Debug.Log ("Vida: " + PersistentData.Lifes);
			if (PersistentData.Lifes <= 0) {
				PersistentData.IsPlayerDead = true;
			}
		}
	}

	void OnTriggerExit2D(Collider2D col){
		// Cuando nos alejamos del boss después de darle un golpe, este recupera su color original
		if (col.gameObject.layer == Layers.Player && gameObject.tag == "Boss") {
			iTween.ColorTo (gameObject, _originalBossColor, 1);
		}
	}
}
