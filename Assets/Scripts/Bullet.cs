using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	public Vector2 movementDirection;
	public float speed;

	public float lifetime = 1.0f;

	void Start () {
		
	}
	

	void Update () {
		this.GetComponent<Rigidbody2D> ().velocity = movementDirection * speed;

		lifetime -= Time.deltaTime;
		if (lifetime <= 0) {
			Destroy (this.gameObject);
		}
	}
}
