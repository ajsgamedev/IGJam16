using UnityEngine;
using System.Collections;
using UnityEngine.UI; 


public class Player : MonoBehaviour
{

	public float maskTime;
	public float speed;
	public static float runningSpeed;

	public MaskType currentMask;
	bool maskActivated;


	SpriteRenderer renderer;


	// Use this for initialization
	void Start ()
	{
		
		runningSpeed = speed;


	}
	
	// Update is called once per frame
	void Update ()
	{
		

	}

}


public enum MaskType
{
	BlueBird,
	GreenBird,
	YellowBird
}