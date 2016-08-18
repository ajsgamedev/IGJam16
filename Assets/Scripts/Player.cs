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

	public LayerMask whatIsGround;
	public Transform groundCheck;


	SpriteRenderer renderer;


	// Use this for initialization
	void Start ()
	{
		
		renderer = GetComponent<SpriteRenderer> ();
		runningSpeed = speed;


	}
	
	// Update is called once per frame
	void Update ()
	{
		
		//Movement
		transform.Translate (runningSpeed * Time.deltaTime, 0, 0);

	}

}


public enum MaskType
{
	BlueBird,
	GreenBird,
	YellowBird
}