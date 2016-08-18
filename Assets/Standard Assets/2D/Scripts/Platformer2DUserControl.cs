using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using System.Collections.Generic;
using System.Linq;

namespace UnityStandardAssets._2D
{
    [RequireComponent(typeof (PlatformerCharacter2D))]
    public class Platformer2DUserControl : MonoBehaviour
    {
        private PlatformerCharacter2D m_Character;
        private bool m_Jump;

		private Vector2 fingerStart;
		private Vector2 fingerEnd;

		public enum Movement
		{
			Up,
			Down
		};

		public List<Movement> movements = new List<Movement> ();

        private void Awake()
        {
            m_Character = GetComponent<PlatformerCharacter2D>();
        }


        private void Update()
        {
			if (Input.GetMouseButtonDown (0))
			{
				fingerStart = Input.mousePosition;
				fingerEnd = Input.mousePosition;
			}

			if (Input.GetMouseButton (0))
			{
				fingerEnd = Input.mousePosition;

				//There was some movement! The tolerance variable is to detect some useful movement
				//i.e. an actual swipe rather than some jitter. This is the same as the value of 80
				//you used in your original code.
				if (Mathf.Abs (fingerEnd.y - fingerStart.y) > 100)
				{


					if ((fingerEnd.y - fingerStart.y) > 0)
					{
						//Up


					}
					else
					{
						//Down

					}

					//After the checks are performed, set the fingerStart & fingerEnd to be the same
					fingerStart = fingerEnd;

					//Now let's check if the Movement pattern is what we want
					//In this example, I'm checking whether the pattern is Left, then Right, then Left again
					//Debug.Log (CheckForPatternMove(0, 3, new List<Movement>() { Movement.Left, Movement.Right, Movement.Left } ));
				}
			}



			//GetMouseButtonUp(0) instead of TouchPhase.Ended
			if (Input.GetMouseButtonUp (0))
			{
				fingerStart = Vector2.zero;
				fingerEnd = Vector2.zero;
				movements.Clear ();
			}

            if (!m_Jump)
            {
                // Read the jump input in Update so button presses aren't missed.
                m_Jump = CrossPlatformInputManager.GetButtonDown("Jump");
            }
        }


        private void FixedUpdate()
        {
          
            // Pass all parameters to the character control script.
			bool slide = Input.GetKey(KeyCode.LeftControl);
			m_Character.Move(1, slide, m_Jump);
            m_Jump = false;
        }
    }
}
