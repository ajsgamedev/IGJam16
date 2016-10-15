using UnityEngine;
using System.Collections;

public class BigBird : MonoBehaviour {

    public MaskType maskType;
    Animator anim;
    public float warnDistance;
    public int pointsToScore;

    FlyAway fly;

    bool shouldWarn = true;

	// Use this for initialization
	void Start () {

        anim = GetComponent<Animator>();
        fly = GetComponent<FlyAway>();
	}
	
	// Update is called once per frame
	void Update () {
        float dist = Vector3.Distance(GameManager.instance.player.transform.position, this.transform.position);
	    if(shouldWarn && Vector3.Distance(GameManager.instance.player.transform.position,this.transform.position) <= warnDistance)
        {
            shouldWarn = false;
            anim.SetTrigger("warn");
        }
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (GameManager.instance.player.currentMask == maskType)
        {
            getScared();
        }
        else
        {
            notGetScared();
        }
        shouldWarn = true;
    }

    void getScared()
    {
        //PlayFancyStuff
        ScoreManager.instance.score += pointsToScore;
        fly.StartFly();
    }

    void notGetScared()
    {
        //PlayOtherFancyStuff
        GameManager.instance.hearts--;
        GameManager.instance.refreshUI();
        transform.Translate(0, 100, 0);


    }
}
