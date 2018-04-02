using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour {
	public int scoreToSecondLevel = 2;
	public int scoreToThirdLevel = 4;

	public AudioClip FirstLevelBackgroundMusic, ThirdLevelBackgroundMusic;

	private AudioSource _audio;	// El sonido para al entrar al juego desde el menú

	void Start(){
		DontDestroyOnLoad (gameObject);
		_audio = GetComponent<AudioSource> ();
	}

	void Update(){
		if (!PersistentData._isPlayerDead) {
			// Antes de cargar una escena una vez conseguida la punutación necesaria, comprobar que no se ha cargado ya
			if (PersistentData.Score == 0 && PersistentData._isFirstLevelLoaded) {
				// Si se acaba de cargar el primer nivel, lanza su música respectiva
				_audio.clip = FirstLevelBackgroundMusic;
				_audio.PlayDelayed (1);	// Para que la música del primer nivel no se solape con el sonido al pulsar el botón del menú
				PersistentData._isFirstLevelLoaded = false;
			} else if (PersistentData.Score == scoreToSecondLevel && !PersistentData._isSecondLevelLoaded) {
				LoadScene (2);
				PersistentData._isSecondLevelLoaded = true;
			} else if (PersistentData.Score == scoreToThirdLevel && !PersistentData._isThirdLevelLoaded) {
				LoadScene (3);
				_audio.clip = ThirdLevelBackgroundMusic;
				_audio.Play ();
				PersistentData._isThirdLevelLoaded = true;
			}
		} else {
			LoadScene (0);
			PersistentData._isPlayerDead = false;	// Recuperamos la vida y empezamos de nuevo. TODO quitarle el guión a las variables de PersistentData porque son públicas
			PersistentData.Score = 0;
			PersistentData.Lifes = 3;
			_audio.Stop();
		}
	}

	private void LoadScene(int index){
		SceneManager.LoadScene (index);
	}

	public void StartGame(){
		_audio.Play ();
		LoadScene (1);
		PersistentData._isFirstLevelLoaded = true;
	}
}
