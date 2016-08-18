using UnityEngine;
using System.Collections;

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
		//currentMask = MaskType.Crow;
		renderer = GetComponent<SpriteRenderer> ();
		runningSpeed = speed;
	}
	
	// Update is called once per frame
	void Update ()
	{
		//Input
		if (Input.GetKeyDown (KeyCode.A))
		{
			SwipeMask (false);
		}
		else
		if (Input.GetKeyDown (KeyCode.D))
		{
			SwipeMask (true);
		}

		if (Input.GetKeyDown (KeyCode.Space))
		{
			StartCoroutine ("ActivateMask");
		}
		//Movement
		transform.Translate (runningSpeed * Time.deltaTime, 0, 0);
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
		case MaskType.BlueBird:
			renderer.material.color = Color.blue;
			break;
		case MaskType.GreenBird:
			renderer.material.color = Color.green;
			break;
		case MaskType.YellowBird:
			renderer.material.color = Color.yellow;
			break;
		}
	}

	public void Jump ()
	{				
		float jumpVal;

		jumpVal = this.gameObject.transform.position.y + 2.0f;
		//this.gameObject.transform.position.y = jumpVal;
		transform.Translate (transform.position.x, jumpVal*Time.deltaTime,0 );
	}

	public void Slide()
	{

	}
    
}



public enum MaskType
{
	BlueBird,
	GreenBird,
	YellowBird
}
