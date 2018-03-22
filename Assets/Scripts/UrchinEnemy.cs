using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UrchinEnemy : MonoBehaviour {
	public float GuardRadius = 5.0f;	// Radio en el que el jugador sería visto y perseguido
	public float KillRadius = 1.0f;	// Radio en el que el jugador moriría
	public float PursueSpeed = 5.0f;	// La velocidad a la que el enemigo persigue al jugador

	private Rigidbody2D _rb;
	private Color _originalColor;

	// Use this for initialization
	void Start () {
		_rb = GetComponent<Rigidbody2D> ();
		_originalColor = GetComponent<SpriteRenderer> ().color;
	}

	void Update(){
		Collider2D col = Physics2D.OverlapCircle (new Vector2 (transform.position.x, transform.position.y), GuardRadius, 1 << Layers.Player);

		if (col != null) {
			// TODO o le quita una vida?
			Debug.Log ("Jugador alcanzado por erizo");

			iTween.PunchScale (gameObject, iTween.Hash ("amount", Vector3.one * .8f, "looptype", iTween.LoopType.loop, "time", PursueSpeed / 5));
			iTween.ColorTo (gameObject, Color.red, PursueSpeed);

			// Calculo la dirección del enemigo al jugador
			Vector3 direction = col.gameObject.transform.position - transform.position;
			// Le doy velocidad al enemigo en la dirección calculada
			_rb.velocity = new Vector2 (direction.x, direction.y).normalized * PursueSpeed;


			// Si en algún momento el jugador se acerca demasiado al enemigo, muere
			float distanceToPlayer = Vector3.Distance (transform.position, col.gameObject.transform.position);
			if (distanceToPlayer <= KillRadius) {
				Debug.Log ("Demasiado cerca! " + distanceToPlayer);
			}
		} else {
			Debug.Log ("Fuera de peligro");
			iTween.ColorTo (gameObject, _originalColor, PursueSpeed);
		}
	}
		
	void OnDrawGizmos(){
		Gizmos.color = Color.green;
		Gizmos.DrawWireSphere (transform.position, GuardRadius);

		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere (transform.position, KillRadius);
	}
}
