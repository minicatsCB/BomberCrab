using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour {
	public GameObject ShootPrefab;	// El objeto que lanza el boss cuando ataca
	public float ShootingRate = 0.25f;
	public float Speed = 2.0f;	// Velocidad a la que se mueve el objeto

	private GameObject _target;	// Contra quién queremos lanzar el objeto
	private float _shootCooldown;
	private Transform _bulletsParent;	// Para organizar la escena

	public bool CanAttack{ get { return _shootCooldown <= 0.0f; }}

	// Use this for initialization
	void Start () {
		_target = GameObject.FindGameObjectWithTag ("Player");
		_shootCooldown = 0.0f;
		_bulletsParent = new GameObject("Bullets").transform;
	}
	
	// Update is called once per frame
	void Update () {
		if (_shootCooldown > 0) {
			_shootCooldown -= Time.deltaTime;
		}

		Attack ();
	}

	public void Attack(){
		if (CanAttack) {
			_shootCooldown = ShootingRate;

			// Crea un nuevo objeto
			GameObject go = Instantiate(ShootPrefab);
			go.transform.position = transform.position;
			go.transform.parent = _bulletsParent;	// Para organizar la escena

			go.GetComponent<Rigidbody2D> ().velocity = _target.transform.position.normalized * Speed;	// Le damos velocidad al objeto
		}
	}
}
