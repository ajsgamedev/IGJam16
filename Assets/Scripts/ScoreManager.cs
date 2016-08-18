using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class ScoreManager : MonoBehaviour {

	public int score;

	Text text;

	// Use this for initialization
	void Awake () 
	{
		text = GetComponent<Text> ();
		score = 0;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (score < 0)
		{
			score = 0;
		}

		text.text = "Score: " + score;
	}
}
