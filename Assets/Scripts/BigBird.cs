using UnityEngine;
using System.Collections;

public class BigBird : MonoBehaviour {

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        if(other.name == "BlueBird")
        {
            if(GameManager.instance.player.currentMask == MaskType.BlueBird)
            {
                scareBird();
            }
            else
            {
                notScareBird();
            }
        }
        else if(other.name == "GreenBird")
        {
            if (GameManager.instance.player.currentMask == MaskType.GreenBird)
            {
                scareBird();
            }
            else
            {
                notScareBird();
            }
        }
        else if(other.name == "YellowBird")
        {
            if (GameManager.instance.player.currentMask == MaskType.YellowBird)
            {
                scareBird();
            }
            else
            {
                notScareBird();
            }
        }
    }

    void scareBird()
    {
        //PlayFancyStuff
        transform.Translate(0, 100, 0);
    }

    void notScareBird()
    {
        //PlayOtherFancyStuff
        GameManager.instance.hearts--;
        GameManager.instance.refreshUI();


    }
}
