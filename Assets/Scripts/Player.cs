using UnityEngine;
using System.Collections;
using UnityEngine.UI; 


public class Player : MonoBehaviour
{

	public float maskTime;
	public float speed;
	public static float runningSpeed;

	public GameObject GMask;
	public GameObject BMask;
	public GameObject OMask;

	public MaskType currentMask;
	bool maskActivated;
    public static Player instance;

	void Awake()
    {
        instance = this;
		GMask.SetActive (false);
		OMask.SetActive (false);
		BMask.SetActive (false);
    }

	// Use this for initialization
	void Start ()
	{
		
		runningSpeed = speed;


	}
	
	// Update is called once per frame
	void Update ()
	{
		

	}

	public void BlueClick()
	{
		GMask.SetActive (false);
		OMask.SetActive (false);
		BMask.SetActive (true);
		currentMask = MaskType.BlueBird;

	}

	public void OrangeClick()
	{
		GMask.SetActive (false);
		OMask.SetActive (true);
		BMask.SetActive (false);
		currentMask = MaskType.YellowBird;

	}

	public void GreenClick()
	{
		GMask.SetActive (true);
		OMask.SetActive (false);
		BMask.SetActive (false);
		currentMask = MaskType.GreenBird;

	}
		
}


public enum MaskType
{
	BlueBird,
	GreenBird,
	YellowBird
}