using UnityEngine;
using System.Collections;

public class mouseManager : MonoBehaviour {

	public GameObject prefab;
	public Camera camera;
	public float alpha;
	public float limit;

	private GameObject clone;
	private Vector3 mouse;

	void Start () {
	}

	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			StartCoroutine ("OnMouseDown");
		}
		if (clone != null) {
			clone.gameObject.transform.localScale += new Vector3 (alpha, alpha, 0.0f);
		}

	}

	IEnumerator OnMouseDown() {
		mouse = Input.mousePosition;
		Vector3 foo = camera.ScreenToWorldPoint (mouse);
		foo.z = 0;
		//Debug.Log ("Mouse Position: " + foo);
		clone = (GameObject)Instantiate (prefab, foo, Quaternion.identity);
		yield return new WaitWhile (() => clone.gameObject.transform.localScale.x<limit&&Input.GetMouseButton(0));
		Destroy (clone);
	}
}