using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateBossCanvas : MonoBehaviour {
	private Text _bossLifesGUIText;	// El texto de las vidas restantes del boss

	private string warningMessage = "Por favor, comprueba que la siguiente etiqueta está asignada en el editor a el objeto correpondiente: ";

	// Use this for initialization
	void Start () {
		// Inicializamos el texto de la GUI que marca las vidas restantes del boss
		GameObject _bossLifesGUI = GameObject.FindGameObjectWithTag("BossLifesText");
		if (_bossLifesGUI) {
			_bossLifesGUIText = _bossLifesGUI.GetComponent<Text> ();
			_bossLifesGUIText.text = "Boss lifes: " + PersistentData.BossLifes;
		} else {
			Debug.LogWarning (warningMessage + "BossLifesText");
		}
	}
	
	// Update is called once per frame
	void Update () {
		UpdateScore ();
	}

	// Se llama desde el Detect By Contact
	public void UpdateScore(){
		if (_bossLifesGUIText) {
			// Actualizamos la puntuación en la GUI
			_bossLifesGUIText.text = "Boss Lifes: " + PersistentData.Score;
		} else {
			Debug.LogWarning (warningMessage + "BossLifesText");
		}
	}
}
