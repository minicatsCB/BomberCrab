using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowDiscoveredPath : MonoBehaviour {
	public GameObject TrailTile;	// La estela del jugador
	public float trailTileTime = 3.0f;	// Lo que dura la estela

	// Para evitar que se creen muuuuchas tiles seguidas
	private Vector3 _lastPosition;	// La última posición en la que se creó una tile
	private float _distance = 0.4f;	// La distancia entre posición y posición para la que quiero que se cree una tile

	// Use this for initialization
	void Start () {
		//StartCoroutine (createTrailTile ());
		_lastPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log ("Distance: " + Vector3.Distance (_lastPosition, transform.position));
		if (Vector3.Distance (_lastPosition, transform.position) >= _distance) {
			Debug.Log ("Crear tile");
			// Creo una tile en la posición del jugdor
			Vector3 spawnPosition = new Vector3 (transform.position.x, transform.position.y, -1);
			Quaternion spawnRotation = Quaternion.Euler (new Vector3 (-90, 0, 0));
			GameObject tile = Instantiate(TrailTile, spawnPosition, spawnRotation);
			// La dejo ahí durante 5 segundos
			StartCoroutine(DestroyTrailTile(tile));

			// Cuando creamos una tile, la posición donde se ha creado se convierte en la última posición (la del jugador, porque la Z de la tile no nos interesa)
			_lastPosition = transform.position;
		}
	}

	private IEnumerator DestroyTrailTile(GameObject tile){
		
		yield return new WaitForSeconds (trailTileTime);
		Destroy (tile);
		yield return null;
	}
}
