using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour {
	public float ScrollSpeed;	// A qué velocidad quiero que se mueva el fondo
	public float TileSizeY;	// Cada cuánta distancia en Y quiero comenzar de nuevo el loop

	private Vector3 _startPosition;

	// Use this for initialization
	void Start () {
		_startPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		// Mathf.Repeat() es como un módulo para números decimales
		float newPosition = Mathf.Repeat (Time.time * ScrollSpeed, TileSizeY);
		transform.position = _startPosition + Vector3.up * newPosition;
	}
}
