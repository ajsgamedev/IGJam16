using UnityEngine;
using System.Collections;

public class SmallBird : MonoBehaviour {

    FlyAway fly;

	// Use this for initialization
	void Start () {
        fly = GetComponent<FlyAway>();
        if (fly == null)
            fly = transform.parent.GetComponent<FlyAway>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            fly.StartFly();
        }
    }
}
