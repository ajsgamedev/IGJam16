using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;

public class MobileControls : MonoBehaviour
{
	public Text swipe;
	private Vector2 fingerStart;
	private Vector2 fingerEnd;

	public enum Movement
	{
		Left,
		Right
	};

	public List<Movement> movements = new List<Movement>();

	void Update()
	{
		//Example usage in Update. Note how I use Input.GetMouseButton instead of Input.touch

		//GetMouseButtonDown(0) instead of TouchPhase.Began
		if (Input.GetMouseButtonDown(0)) {
			fingerStart = Input.mousePosition;
			fingerEnd  = Input.mousePosition;
		}

		//GetMouseButton instead of TouchPhase.Moved
		//This returns true if the LMB is held down in standalone OR
		//there is a single finger touch on a mobile device
		if(Input.GetMouseButton(0)) {
			fingerEnd = Input.mousePosition;

			//There was some movement! The tolerance variable is to detect some useful movement
			//i.e. an actual swipe rather than some jitter. This is the same as the value of 80
			//you used in your original code.
			if(Mathf.Abs(fingerEnd.x - fingerStart.x) > 80)
			{

				//There is more movement on the X axis than the Y axis
				if(Mathf.Abs(fingerStart.x - fingerEnd.x) > Mathf.Abs(fingerStart.y - fingerEnd.y)) 
				{
					
					if ((fingerEnd.x - fingerStart.x) > 0)
					{
						//Right Swipe
						movements.Add (Movement.Right);
						swipe.text = "Swipe: Right!!";
					}
					else
					{
						//Left Swipe
						movements.Add (Movement.Left);
						swipe.text = "Swipe: Left!!";

					}
				}

				//After the checks are performed, set the fingerStart & fingerEnd to be the same
				fingerStart = fingerEnd;

				//Now let's check if the Movement pattern is what we want
				//In this example, I'm checking whether the pattern is Left, then Right, then Left again
				//Debug.Log (CheckForPatternMove(0, 3, new List<Movement>() { Movement.Left, Movement.Right, Movement.Left } ));
			}
		}

		//GetMouseButtonUp(0) instead of TouchPhase.Ended
		if(Input.GetMouseButtonUp(0)) 
		{
			fingerStart = Vector2.zero;
			fingerEnd = Vector2.zero;
			movements.Clear();
		}
			
	}
}