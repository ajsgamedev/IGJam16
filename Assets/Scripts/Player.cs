using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public float runningSpeed;
    public MaskType currentMask;
    SpriteRenderer renderer;
	// Use this for initialization
	void Start () {
        currentMask = MaskType.Crow;
        renderer = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        //Input
	    if(Input.GetKeyDown(KeyCode.A))
        {
            SwipeMask(false);
        }
        else if(Input.GetKeyDown(KeyCode.D))
        {
            SwipeMask(true);
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            ActivateMask();
        }
        //Movement
        transform.Translate(runningSpeed * Time.deltaTime, 0, 0);
	}

    void ActivateMask()
    {
        
    }

    void SwipeMask(bool direction)
    {
        if(direction)
        {
            currentMask += 1;
            if((int)currentMask >= 3)
            {
                currentMask = (MaskType)0;
            }
        }
        else
        {
            currentMask -= 1;
            if(currentMask < 0)
            {
                currentMask = (MaskType)2;
            }
        }
        switch(currentMask)
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

    
}

public enum MaskType
{
    Crow,
    Bull,
    Mice
}
