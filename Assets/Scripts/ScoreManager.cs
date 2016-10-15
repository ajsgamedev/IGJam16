using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class ScoreManager : MonoBehaviour {

	public int score;

	public Text text;

    public static ScoreManager instance;

	// Use this for initialization
	void Awake () 
	{
        instance = this;
		//text = GetComponent<Text> ();
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
