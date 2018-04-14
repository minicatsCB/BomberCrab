using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
	public GameObject[] Enemies;
	public float FallingSpeed = 3;	// La velocidad a la que caen los enemigos
	public float spawnWait = 1;	// Tiempo que pasa entre que sale un enemigo y otro
	public float startWait = 1;	// Tiempo entre una oleada y otra
	public float waveWait = 1;	// Frecuencia de las oledas
	public GameObject CoconutPrefab;

	// Mapa
	public GameObject groundPrefab;
	private int _mapHeight = 16;
	private int _mapWidth = 10;

	private Transform _enemiesParent;	// Para agrupar los enemigos creados y mantener organizada la escena
	private Transform _palmTreesParent;	// Objeto que agrupa todas las palmeras

	void Awake(){
		/*
		// Creamos trablero
		// Creamos un objeto en la jerarquía llamado map que va a contener todas las filas del suelo intanciadas
		Transform mapParent = new GameObject("Map").transform;
		for (int row = -_mapHeight/2; row < _mapHeight/2; row++) {
			// Igualmente, vamos a tener un objeto que va a contener cada tile
			Transform rowTransform = new GameObject ("Row_" + row).transform;
			for (int col = -_mapWidth/2; col < _mapWidth/2; col++) {
				Vector3 spawnPosition = new Vector3 ((float)col * 0.7f, (float)row * 0.7f, 0.0f);
				Quaternion spawnRotation = Quaternion.Euler (new Vector3 (-90, 0, 0));
				GameObject go = GameObject.Instantiate (groundPrefab, spawnPosition, spawnRotation);	// Baldosa instanciada
				go.name = "Col_" + col;
				go.transform.parent = rowTransform;	// Hacemos la baldosa hija de la fila (cada baldosa coincide con el número de columna)
			}
			rowTransform.parent = mapParent;
		}
		*/

		_enemiesParent = new GameObject ("Enemies").transform;
		GameObject palmTreesParent = GameObject.FindGameObjectWithTag ("PalmTrees");
		_palmTreesParent = palmTreesParent.transform;
	}

	// Use this for initialization
	void Start () {
		StartCoroutine (SpawnWaves());
		StartCoroutine (ThrowCoconuts ());
	}

	private IEnumerator SpawnWaves(){
		yield return new WaitForSeconds (startWait);
		while (true) {
			Debug.Log ("Nueva oleada");
			for(int i = 0; i < Enemies.Length; i++){
				// Crea enemigos en la parte de arriba del tablero
				Vector3 spawnPosition = new Vector3 (Random.Range (Boundary.xMin, Boundary.xMax), Boundary.yMax, 0);
				Quaternion spawnRotation = Quaternion.identity;
				GameObject go = Instantiate(Enemies [Random.Range (0, Enemies.Length)], spawnPosition, spawnRotation);
				go.transform.parent = _enemiesParent;
				go.GetComponent<Rigidbody2D>().velocity = -go.transform.up * FallingSpeed;	// Los enemigos van cayendo
				yield return new WaitForSeconds(spawnWait);
			}
			yield return new WaitForSeconds (waveWait);
		}
	}

	private IEnumerator ThrowCoconuts(){
		yield return new WaitForSeconds (startWait);
		while (true) {
			Debug.Log ("Nueva oleada");
			// Elegimos aleatoriamente una palmera de todas las que hay en la escena
			int randomPalmTreeIndex = Random.Range (0, _palmTreesParent.childCount - 1);
			// Instanciamos un coco en esa posición
			Vector3 spawnPosition = _palmTreesParent.GetChild(randomPalmTreeIndex).transform.position;
			Quaternion spawnRotation = Quaternion.identity;
			GameObject go = Instantiate(CoconutPrefab, spawnPosition, spawnRotation);
			go.GetComponent<Rigidbody2D>().velocity = -go.transform.up * FallingSpeed;	// El coco cae en la arena y ya está
			yield return new WaitForSeconds (waveWait);
		}
	}
}
