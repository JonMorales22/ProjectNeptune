using UnityEngine;
using System.Collections;

public class TextObject : MonoBehaviour {
	private Vector3 origin;
	private Transform CoOrd1;
	private Transform CoOrd2;
	// Use this for initialization
	void Start () {
		origin = transform.position;
	}

	public Vector3 getOrigin()
	{
		return origin;
	}

}
