using UnityEngine;
using System.Collections;

public class spawnTarget : MonoBehaviour {
	public GameObject prefab;
	public GameObject clone;
	// Use this for initialization
	void Start () {
		StartCoroutine ("SpawnNewLocation");
	}
		
	IEnumerator SpawnNewLocation() {
		float randX = Random.Range(-4,4);
		float randY = Random.Range(-3,4);
		targetScript t = clone.GetComponent( typeof(targetScript) ) as targetScript;
		yield return new WaitUntil (() => t.poop==true);
		Destroy(clone);
		clone = (GameObject)Instantiate (prefab, new Vector3(randX,randY,0.0f) , Quaternion.identity);
		StartCoroutine ("SpawnNewLocation");
	}
}
