using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectItem : MonoBehaviour {
	public AudioClip CoconutAudio;

	void OnTriggerEnter2D(Collider2D col){
		if (col.tag == "Coconut") {
			AudioSource.PlayClipAtPoint(CoconutAudio, transform.position);
			PersistentData.Lifes++;
			Destroy (col.gameObject);
		}
	}
}
