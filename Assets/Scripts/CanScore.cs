using UnityEngine;
using System.Collections;

public class CanScore : MonoBehaviour {

    public int pointsToScore;

	void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            ScoreManager.instance.score += pointsToScore;
        }
    }
}
