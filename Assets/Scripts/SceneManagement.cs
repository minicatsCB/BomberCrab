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
		if (!PersistentData.IsPlayerDead) {
			// Antes de cargar una escena una vez conseguida la punutación necesaria, comprobar que no se ha cargado ya
			if (PersistentData.Score == 0 && PersistentData.IsFirstLevelLoaded) {
				// Si se acaba de cargar el primer nivel, lanza su música respectiva
				_audio.clip = FirstLevelBackgroundMusic;
				_audio.PlayDelayed (1);
				PersistentData.IsFirstLevelLoaded = false;
			} else if (PersistentData.Score == ScoreToSecondLevel && !PersistentData.IsSecondLevelLoaded) {
				LoadScene (2);
				PersistentData.IsSecondLevelLoaded = true;
			} else if (PersistentData.Score == ScoreToThirdLevel && !PersistentData.IsThirdLevelLoaded) {
				LoadScene (3);
				_audio.clip = ThirdLevelBackgroundMusic;
				_audio.Play ();
				PersistentData.IsThirdLevelLoaded = true;
			}
		} else {
			Time.timeScale = 0;
			_audio.Stop();
			if (!PersistentData.IsGameOverScreenLoaded) {
				LoadScene (4);
				PersistentData.IsGameOverScreenLoaded = true;
			}
		}

		if (PersistentData.IsBossDead) {
			if (!PersistentData.IsWinScreenLoaded) {
				LoadScene (5);
				_audio.clip = PlayerWonClip;
				_audio.loop = false;	// Queremos que este audio se reproduzca solo una vez
				_audio.Play ();
				PersistentData.IsWinScreenLoaded = true;
			}
		}
	}

	public void StartGame(){
		LoadScene (1);
		PersistentData.IsFirstLevelLoaded = true;
	}

	private void LoadScene(int index){
		SceneManager.LoadScene (index);
	}
}
