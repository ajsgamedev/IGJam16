using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class points : MonoBehaviour {


	public int scoreVal = 10;
	public Text text;

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.tag == "Player")
		{
			text.text = "Score: " + scoreVal;
		}
	}
}
