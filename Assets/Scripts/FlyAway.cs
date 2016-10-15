using UnityEngine;
using System.Collections;

public class FlyAway : MonoBehaviour {

    public float flyTime;
    public float flySpeed;
    bool flying = false;

	public void StartFly()
    {
        StartCoroutine("Fly");
        flying = true;
    }

    void Update()
    {
        if(flying)
        {
            transform.Translate(flySpeed * Time.deltaTime * 2,flySpeed * Time.deltaTime,0);
        }
    }

    IEnumerable Fly()
    {
        yield return new WaitForSeconds(flyTime);
        flying = false;
    }
}
