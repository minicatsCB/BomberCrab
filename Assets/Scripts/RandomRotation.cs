using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class RandomRotation : MonoBehaviour {
	public float rotationSpeed = 5;

	private Rigidbody2D _rb;

	// Use this for initialization
	void Start () {
		_rb = GetComponent<Rigidbody2D> ();
		_rb.angularVelocity = Random.insideUnitCircle.magnitude * rotationSpeed;
	}
}
