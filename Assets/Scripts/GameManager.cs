using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {
    public float tileWidth;
    public List<Transform> tilesInUse;
    public List<Transform> tilePool;

    float movedDistance = 0;
    Vector3 lastPos;
	// Use this for initialization
	void Start () {
        SetupTiles();
	}

    void SetupTiles()
    {
        float horzExtent = Camera.main.orthographicSize * Screen.width / Screen.height;
        horzExtent *= 2;
        int tilesNeeded = (int)(horzExtent / tileWidth) + 2;
        float startPoint = horzExtent * -0.5f; 
        for(int i = 0; i < tilesNeeded;i++)
        {
            int randomNumber = Random.Range(0, tilePool.Count);
            lastPos = new Vector3(startPoint + (tileWidth * i), 0, 0);
            tilePool[randomNumber].localPosition = lastPos;
            tilesInUse.Add(tilePool[randomNumber]);
            tilePool.RemoveAt(randomNumber);
        }
    }

	// Update is called once per frame
	void Update () {
        movedDistance += Player.runningSpeed * Time.deltaTime;
        if(movedDistance >= tileWidth)
        {
            movedDistance -= tileWidth;
            lastPos.x += tileWidth;
            tilePool.Add(tilesInUse[0]);
            tilesInUse.RemoveAt(0);

            int randomNumber = Random.Range(0, tilePool.Count);
            tilePool[randomNumber].localPosition = lastPos;
            tilesInUse.Add(tilePool[randomNumber]);
            tilePool.RemoveAt(randomNumber);
        }
	}
}
