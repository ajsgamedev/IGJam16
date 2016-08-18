using UnityEngine;
using System.Collections;
using UnityEngine.UI; 


public class Player : MonoBehaviour
{

	public float maskTime;
	public float speed;
	public static float runningSpeed;
	public float jumpForce = 5.0f;

	public MaskType currentMask;
	bool maskActivated;

	public LayerMask whatisGround;
	public Transform groundCheck;

	bool isGrounded = true;

	SpriteRenderer renderer;
	Rigidbody2D rigidb;

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

		if (isGrounded == false)
		{
			isGrounded = true;
		}
	}

}



public enum MaskType
{
	BlueBird,
	GreenBird,
	YellowBird
}