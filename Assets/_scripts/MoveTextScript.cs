using UnityEngine;
using System.Collections;

public class MoveTextScript : MonoBehaviour {

	private Vector3 newPos;

	private Transform[] wordArray;
	private Rigidbody playerRb;
	private float distance;
	// Use this for initialization
	void Start () {
		distance = Mathf.Infinity;
		playerRb = GameObject.FindWithTag("Player").GetComponent<Rigidbody> ();
		wordArray = GetComponentsInChildren<Transform>();
		StartCoroutine ("MoveText");
	}
	private void randomText()
	{
		

	}

	public IEnumerator MoveText()
	{
		Debug.Log ("Position: " + wordArray[1].transform.position);
		while(distance > 0.01f)
		{
			float delta = playerRb.velocity.x/10;
			//Debug.Log ("Delta: " + delta);
			for (int i = 1; i < wordArray.Length; i++) {
				newPos = new Vector3 (wordArray [i].position.x, 0, 0);
				wordArray[i].position = Vector3.MoveTowards (wordArray[i].position, newPos, delta);
				//wordArray [i].position  -= new Vector3(0,delta,0);
			
			}

			//wordArray[1].position

			float xVal = Mathf.Abs(wordArray[1].position.x)*2;
			float yVal = Mathf.Abs(wordArray[1].position.y)*2;

			distance = Mathf.Sqrt (xVal + yVal);
			Debug.Log ("Distance: " + distance);
			yield return new WaitForSeconds (.01f);
		}


	}
}
