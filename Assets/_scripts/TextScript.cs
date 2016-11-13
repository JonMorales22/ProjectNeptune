using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextScript : MonoBehaviour {
	private Graphic graphic;
	private Color color;
	private Rigidbody playerRb;
	public float delta;

	void Start () {
		graphic = GetComponent<Graphic>();
		playerRb = GameObject.FindWithTag ("Player").GetComponent<Rigidbody> ();
		color = graphic.color;
		color.a = 1;
		StartCoroutine ("FadeOut");
	}
		
	public IEnumerator FadeOut()
	{


		while (Mathf.Abs(0-color.a) >.001)
		{

			color.a -= playerRb.velocity.x / 100;
			graphic.color = color;
			yield return new WaitForSeconds (.1f);
		}
		StartCoroutine ("FadeIn");
	}

	public IEnumerator FadeIn()
	{

		while (Mathf.Abs(1 - color.a) >.001)
		{
			Debug.Log ("Alpha: " + color);
			//Debug.Log (playerRb.velocity/10);
			color.a -= playerRb.velocity.x / 100;
			graphic.color = color;
			yield return new WaitForSeconds (.1f);
		}
		StartCoroutine ("FadeOut");
	}
}
