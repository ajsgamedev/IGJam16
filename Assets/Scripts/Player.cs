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
		currentMask = MaskType.Crow;
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

	IEnumerable ActivateMask ()
	{
		maskActivated = true;
		switch (currentMask)
		{
		case MaskType.Crow:

			break;
		case MaskType.Bull:

			break;
		case MaskType.Mice:

			break;
		}
		yield return new WaitForSeconds (maskTime);
		maskActivated = false;
	}

	void SwipeMask (bool direction)
	{
		if (direction)
		{
			currentMask += 1;
			if ((int)currentMask >= 3)
			{
				currentMask = (MaskType)0;
			}
		}
		else
		{
			currentMask -= 1;
			if (currentMask < 0)
			{
				currentMask = (MaskType)2;
			}
		}
		switch (currentMask)
		{
		case MaskType.Crow:
			renderer.material.color = Color.blue;
			break;
		case MaskType.Bull:
			renderer.material.color = Color.green;
			break;
		case MaskType.Mice:
			renderer.material.color = Color.grey;
			break;
		}
	}

	public void OnTriggerStay (Collider other)
	{
        
		if (other.name == "Enemy1" || other.name == "Enemy3")
		{
			GameManager.instance.Lose ();
		}
		if (other.name == "Enemy2" && !(maskActivated && currentMask == MaskType.Bull))
		{
			GameManager.instance.Lose ();
		}
	}

	public void Jump()
	{
		//rigidb.velocity = new Vector2 (0, jumpForce);
	}

	public void Slide ()
	{

	}

}



public enum MaskType
{
	Crow,
	Bull,
	Mice
}
