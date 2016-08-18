using UnityEngine;
using System.Collections;

public class HurdleBehaviour : MonoBehaviour
{
	public GameManager gm;


	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.tag == "Player")
		{
			gm.hearts--;
			gm.refreshUI ();
		}
	}
		

}
