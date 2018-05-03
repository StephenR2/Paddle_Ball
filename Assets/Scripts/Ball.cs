/* Stephen Randall
 * 03/16/18
 * This script is responsible for ball, putting ball in play, etc.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
	public float ballInitialVelocity = 600f; // Sets balls velocity
	private Rigidbody rb; 
	private bool BallInPlay; // Flag for when the ball is in play.
	private Vector3 DirectionPoint;
	private Quaternion Rotating;


	// Use this for initialization
	void Awake () {
		rb = GetComponent<Rigidbody> (); // Makes it a rigidbody


	}
	void FixedUpdate (){
//		Debug.Log ("Enter Update");
		if ((Input.touchCount > 0) && (Input.GetTouch (0).phase == TouchPhase.Began)) {
//			Debug.Log ("Touched");
			Ray raycast = Camera.main.ScreenPointToRay (Input.GetTouch (0).position);
			RaycastHit raycastHit = new RaycastHit ();
			if (Physics.Raycast (raycast, out raycastHit)) {
//				raycastHit.point = DirectionPoint;
//				transform.LookAt (raycastHit.point);
//				rb.isKinematic = false;
//				rb.AddRelativeForce (raycastHit.point * 100);
				Serve (raycastHit.point);
			}

		}
	}

		

	// Update is called once per frame
		void Serve (Vector3 touchpos)
	{
		
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hit;
		if (Physics.Raycast (ray, out hit)) {
			Vector3 dir = touchpos - transform.position;
			dir = dir.normalized; 
			rb.isKinematic = false;
			transform.LookAt (dir);
			rb.AddRelativeForce (dir * 750);
			//BallInPlay = true;
			//rb.AddForce(new Vector3(-ballInitialVelocity, ballInitialVelocity, 0));
			
		}
	}
}


	