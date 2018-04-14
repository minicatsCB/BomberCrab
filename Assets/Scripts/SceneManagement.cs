using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour {
	public int ScoreToSecondLevel = 2;
	public int ScoreToThirdLevel = 4;
	public int Lifes = 3;

	public AudioClip FirstLevelBackgroundMusic, ThirdLevelBackgroundMusic, PlayerWonClip;

	private AudioSource _audio;	// El sonido para al entrar al juego desde el menú

	void Start(){
		DontDestroyOnLoad(gameObject);
		_audio = GetComponent<AudioSource> ();
	}

	void Update(){
		if (!PersistentData._isPlayerDead) {
			// Antes de cargar una escena una vez conseguida la punutación necesaria, comprobar que no se ha cargado ya
			if (PersistentData.Score == 0 && PersistentData._isFirstLevelLoaded) {
				// Si se acaba de cargar el primer nivel, lanza su música respectiva
				_audio.clip = FirstLevelBackgroundMusic;
				_audio.PlayDelayed (1);
				PersistentData._isFirstLevelLoaded = false;
			} else if (PersistentData.Score == ScoreToSecondLevel && !PersistentData._isSecondLevelLoaded) {
				LoadScene (2);
				PersistentData._isSecondLevelLoaded = true;
			} else if (PersistentData.Score == ScoreToThirdLevel && !PersistentData._isThirdLevelLoaded) {
				LoadScene (3);
				_audio.clip = ThirdLevelBackgroundMusic;
				_audio.Play ();
				PersistentData._isThirdLevelLoaded = true;
			}
		} else {
			Time.timeScale = 0;
			_audio.Stop();
			if (!PersistentData._isGameOverScreenLoaded) {
				LoadScene (4);
				PersistentData._isGameOverScreenLoaded = true;
			}
		}

		if (PersistentData._isBossDead) {
			if (!PersistentData._isWinScreenLoaded) {
				LoadScene (5);
				_audio.clip = PlayerWonClip;
				_audio.Play ();
				PersistentData._isWinScreenLoaded = true;
			}
		}
	}

	public void StartGame(){
		LoadScene (1);
		PersistentData._isFirstLevelLoaded = true;
	}

	private void LoadScene(int index){
		SceneManager.LoadScene (index);
	}
}
