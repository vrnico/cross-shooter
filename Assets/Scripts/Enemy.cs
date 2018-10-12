using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public Vector3 movementDirection;

	public float speed;

	void Start () {
		
	}

	void Update () {
		this.GetComponent<Rigidbody2D> ().velocity = movementDirection * speed;
	}

	void OnTriggerEnter2D (Collider2D c) {

		if (c.gameObject.GetComponent<Bullet> () != null) {
			Destroy (this.gameObject);
			Destroy (c.gameObject);
		}

		if (c.gameObject.GetComponent<Player> () != null) {
			Destroy (c.gameObject);
		}
	}
}
