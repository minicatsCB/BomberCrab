using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour {
	public float Speed = 5;	// La velocidad a la que me quiero move
	private static bool isAtackingState = false;	// Indica si estoy atacando o no

	private Rigidbody2D _rb;
	private Animator _anim;

	// Use this for initialization
	void Start () {
		_rb = GetComponent<Rigidbody2D> ();
		_anim = GetComponent<Animator> ();
	}

	void FixedUpdate () {
		float horizontal = Input.GetAxis ("Horizontal");
		float vertical = Input.GetAxis ("Vertical");

		_rb.velocity = new Vector3(horizontal, vertical, 0) * Speed;

		_rb.position = new Vector3 (
			Mathf.Clamp (_rb.position.x, Boundary.xMin, Boundary.xMax),
			Mathf.Clamp (_rb.position.y, Boundary.yMin, Boundary.yMax),
			0.0f
		);


		// Ataca
		if(Input.GetKey(KeyCode.LeftControl)){
			Debug.Log ("Atacking!");
			isAtackingState = true;
			_anim.SetBool ("isAtacking", isAtackingState);
		} else {
			isAtackingState = false;
			_anim.SetBool ("isAtacking", isAtackingState);
		}

		_anim.SetFloat ("speedX", _rb.velocity.x);
		_anim.SetFloat ("speedY", _rb.velocity.y);
	}

	public static bool isAtacking(){
		return isAtackingState;
	}
}

/*
Guardo todas las baldosas en un array bidimensional. Cuando paso por encima de la casilla se pone a false (no hay colliders). Los objetos
miran si está desbloquedad y si lo está, me muevo a esa casilla desbloquedad, cambiando la posición.


Todas las casillas con colliders. Objetos que están apoyados sobre algo, que es un coolider. Cuando una casilla recibe una colisión por parte del
jugador con el ontriggerenter se desactiva el collider.
*/
