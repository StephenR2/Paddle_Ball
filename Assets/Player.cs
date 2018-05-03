/* Stephen Randall
 * 03/16/18
 * This script is responsible for position of paddle, speed of paddle, etc.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player: MonoBehaviour {
	public float paddleSpeed = .25f; // Sets paddle move speed
	private Vector3 playerPos;
	private float zPos = -9.5f;

	void Start () {
		transform.position = new Vector3 (0, 1, -9.5f);


	}
	// Update is calle
	void Update () {
		float xPos = transform.position.x + (Input.GetAxis ("Horizontal") * paddleSpeed); // Sets position and what axis it moves on
		float yPos = transform.position.y + (Input.GetAxis ("Vertical") * paddleSpeed);
		playerPos = new Vector3 (Mathf.Clamp(xPos, -5f, 5f),Mathf.Clamp(yPos,1f, 7.5f),-9.5f);
		transform.position = playerPos; // Set ball to follow paddle
	}
}
