using UnityEngine;
using System.Collections;

public class targetScript : MonoBehaviour {
	public GameObject prefab;
	public Camera camera;
	public float alpha;
	public float limit;
	public bool poop;

	private CircleCollider2D temp; 
	private GameObject clone;
	private Vector3 mouse;
	private Animator anim;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		poop = false;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (clone != null) {
			clone.gameObject.transform.localScale += new Vector3 (alpha, alpha, 0.0f);
		}
	}

	void OnMouseDown()
	{
		StartCoroutine ("SpawnMarker");
		anim.SetBool ("isClick", true);

	}

	void OnMouseUp()
	{
		anim.SetBool ("isClick", false);
		//StartCoroutine ("SpawnMarker");
	}

	IEnumerator SpawnMarker() {
		/*
		//THIS CODE WORKS
		Rigidbody2D center = GetComponent( typeof(Rigidbody2D) ) as Rigidbody2D;
		clone = (GameObject)Instantiate (prefab, center.worldCenterOfMass, Quaternion.identity);
		yield return new WaitWhile (() => clone.gameObject.transform.localScale.x<limit&&Input.GetMouseButton(0));

		CircleCollider2D temp = GetComponent (typeof(CircleCollider2D)) as CircleCollider2D;
		//float c = temp.radius * 2 * Mathf.PI;
		//Debug.Log ("Radius: "+temp.radius);
		//Debug.Log ("Circumference of player: " + c);
		poop = true;
		Destroy (clone);
		*/

		//FOR DEBUGGING ONLY

		Rigidbody2D center = GetComponent( typeof(Rigidbody2D) ) as Rigidbody2D;
		//clone = (GameObject)Instantiate (prefab, center.worldCenterOfMass, Quaternion.identity);
		yield return new WaitWhile (() => Input.GetMouseButton(0));

		//EdgeCollider2D e = clone.GetComponent (typeof(EdgeCollider2D)) as EdgeCollider2D;
		//Debug.Log ("Position of collider: "+e.transform.position);
		poop = true;
		//Destroy (clone);
	}
}
