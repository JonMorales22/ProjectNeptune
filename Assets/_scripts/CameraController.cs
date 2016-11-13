using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
	private Rigidbody rb;

	public float speed;
	public float maxVelocity;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Vector3 move = new Vector3(speed*Input.GetAxis ("Horizontal"),0,0);
		if (Mathf.Abs (rb.velocity.x) < maxVelocity)
			rb.velocity = move;
		else
			rb.velocity = new Vector3 (maxVelocity * Input.GetAxis ("Horizontal"), 0, 0);
	}
}
