using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

	float speed = 0.1f;

    Rigidbody2D rb;

	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void Update () {
		var direction = new Vector3 (Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0);
		direction.Normalize();
        rb.MovePosition(transform.position + direction * speed);
	}
}
