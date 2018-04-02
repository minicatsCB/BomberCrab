using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterTime : MonoBehaviour {
	public float TimeToLive = 3.0f;

	// Use this for initialization
	void Start () {
		Destroy (gameObject, TimeToLive);
	}
}
