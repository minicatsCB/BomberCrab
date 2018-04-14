using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PersistentObjectsManagement : MonoBehaviour {
	public GameObject ScoreCanvas, SceneManagement;	// Los objetos que queremos mantener activos entre escenas

	void Awake(){
		// ¿En qué escena estamos?
		int activeSceneIndex = SceneManager.GetActiveScene ().buildIndex;
		Debug.Log ("Active scene: " + activeSceneIndex);

		if (activeSceneIndex == 0) {
			// Si estamos en la escena del menú principal, compruebo los objetos correspondientes a esa escena
			if (GameObject.FindGameObjectWithTag ("SceneManagement") == null) {
				Debug.Log ("Instantiating SceneManagement");
				Instantiate (SceneManagement);
			} else {
				Debug.Log ("SceneManagement already exists");
			}
		}

		if (activeSceneIndex == 1) {
			// Si estamos en la escena del primer nivel, compruebo los objetos correspondientes a esa escena
			if (GameObject.FindGameObjectWithTag ("ScoreCanvas") == null) {
				Debug.Log ("Instantiating ScoreCanvas");
				Instantiate (ScoreCanvas);
			} else {
				Debug.Log ("ScoreCanvas already exists");
			}
		}


	}
}
