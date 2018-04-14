using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyExitingObjects : MonoBehaviour {

	void Start(){
	}

	public void OnTriggerExit2D(Collider2D col){
		if (col.tag == "Player") {
			// El jugador nunca se va a salir del área de juego, pero por si acaso
			return;
		} else {
			// Cualquier otro objeto, como un enemigo, que se salga del área de juego, es destruído
			Debug.Log("Objeto fuera del área de juego. Destruyéndolo...");
			Destroy (col.gameObject);
		}
	}
}
