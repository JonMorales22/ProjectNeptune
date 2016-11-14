using UnityEngine;
using System.Collections;

public class MoveTextScript : MonoBehaviour {

	public float radius;

	private Vector3 newPos;
	private Transform[] wordArray;
	private Vector3[] TargetArray;
	private Rigidbody playerRb;
	private float distance;

	// Use this for initialization
	void Start () {
		distance = Mathf.Infinity;
		playerRb = GameObject.FindWithTag("Player").GetComponent<Rigidbody> ();
		wordArray = GetComponentsInChildren<Transform>();
		TargetArray = new Vector3[wordArray.Length];
		RandomText ();
		StartCoroutine ("MoveText");
	}

	/*Method does two things:
	*	1:  Finds a place along a circle to place the words/
	*		letters and then puts the words at that location.
	*		(In this case I just coded for a circle of radius 10)
	*
	*	2:  Finds a point on the opposite side of the circle and saves that point in TargetArray
	*/
	private void RandomText()
	{
		//Right now I'm just using -10 so that when we move the words they end up on the x axis and y axis
		float x1 = -10;
		float y1 = 0;
		float x2, y2;
		for (int i = 1; i < wordArray.Length; i++)
		{
			y1=GetPoint(x1);

			//After we get points on circle we move the letters/words to that point
			wordArray [i].position += new Vector3 (x1, y1, 0);

			//we then find the corresponding point on the OPPOSITE end of the circle and store the point in TargetArray
			x2 = x1 * -1;
			y2 = GetPoint (x2);

			// if the x1 is 0 then we can just multiply y1*-1
			if (x2 != 0)
				TargetArray [i] = new Vector3 (x2, y2, 0);
			else
				TargetArray [i] = new Vector3 (0, -y2, 0);

			//right now I'm just adding by 10 to put the letters on the x axis and y axis
			x1+=10;
		}

	}

	/*Method just uses an equation for a circle to find where to put the words/letters
	 *	equation: (x^2) + (y^2) = r^2
	 */
	private float GetPoint(float x)
	{
		float temp = radius * radius;
		return Mathf.Sqrt (temp - (x * x));
	}
		
	//Method that moves the letters/words from 1 point on the circle to the point on opposite side of the circle.
	public IEnumerator MoveText()
	{
		//we use the distance formula to calculate how far the letters/words are from the target.
		//If we fall within some range, we stop moving the letters/words
		while(distance > 0.01f)
		{
			//we find the rate that we want to move the letters/words based on the player's velocity
			float delta = playerRb.velocity.x/10;

			for (int i = 1; i < wordArray.Length; i++)
			{
				newPos = new Vector3 (wordArray [i].position.x, wordArray[i].position.y, 0);
				wordArray[i].position = Vector3.MoveTowards (wordArray[i].position, TargetArray[i], delta);
			}

			//use the distance formula: sqrt[((x1-x2)^2)-((y1-y2)^2)]
			float xVal = Mathf.Abs(wordArray[1].position.x-TargetArray[1].x)*2;
			float yVal = Mathf.Abs(wordArray[1].position.y-TargetArray[1].y)*2;
			distance = Mathf.Sqrt (xVal + yVal);

			yield return new WaitForSeconds (.01f);
		}



	}

}
