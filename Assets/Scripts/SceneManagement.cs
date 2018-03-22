using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour {
	public int scoreToSecondLevel = 2;
	public int scoreToThirdLevel = 4;

	void Start(){
		DontDestroyOnLoad (gameObject);
	}

	void Update(){
		// Antes de cargar una escena una vez conseguida la punutación necesaria, comprobar que no se ha cargado ya
		if (PersistentData.Score == scoreToSecondLevel && !PersistentData._isSecondLevelLoaded) {
			LoadScene (2);
			PersistentData._isSecondLevelLoaded = true;
		} else if (PersistentData.Score == scoreToThirdLevel && !PersistentData._isThirdLevelLoaded) {
			LoadScene (3);
			PersistentData._isThirdLevelLoaded = true;
		}
	}

	private void LoadScene(int index){
		SceneManager.LoadScene (index);
	}

	public void StartGame(){
		LoadScene (1);
	}
}
