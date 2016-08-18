using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

	public int hearts = 3;
	public GameObject[] UIHearts;

	public float tileWidth;
    public List<Transform> tilesInUse;
    public List<Transform> tilePool;

    public List<Transform> obstaclesInUse;
    public List<Transform> obstaclePool;

    float movedDistance = 0;
    Vector3 lastPos;

    public static GameManager instance;

    //ObstacleSpawnStuff
    public int nextSpawnInterval;
    int currentSpawnInterval;

	// Use this for initialization
	void Start () {
        currentSpawnInterval = nextSpawnInterval;
        SetupTiles();
        instance = this;
	}

    void SetupTiles()
    {
        float horzExtent = Camera.main.orthographicSize * Screen.width / Screen.height;
        horzExtent *= 2;
        int tilesNeeded = (int)(horzExtent / tileWidth) + 3;
        float startPoint = horzExtent * -0.5f;
        startPoint -= tileWidth;
        for(int i = 0; i < tilesNeeded;i++)
        {
            lastPos = new Vector3(startPoint + (tileWidth * i), 0, 0);
            CreateTile();
        }
    }

    void CreateTile()
    {
        int randomNumber = Random.Range(0, tilePool.Count);
        tilePool[randomNumber].localPosition = lastPos;
        tilesInUse.Add(tilePool[randomNumber]);
        tilePool.RemoveAt(randomNumber);
        currentSpawnInterval--;
        if(currentSpawnInterval <= 0)
        {
            int randomNumber2 = Random.Range(0, obstaclePool.Count);
            obstaclePool[randomNumber2].localPosition = lastPos;
            obstaclesInUse.Add(obstaclePool[randomNumber2]);
            obstaclePool.RemoveAt(randomNumber2);

            //Just to ensure the removing happens late enough
            if (obstaclesInUse.Count > 3)
            {
                obstaclePool.Add(obstaclesInUse[0]);
                obstaclesInUse.RemoveAt(0);
            }
            currentSpawnInterval = nextSpawnInterval;
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

            CreateTile();
        }
	}

    public void Lose()
    {

    }

	//refresh UI for health
	public void refreshUI()
	{
		if (hearts <= 0)
		{
			Debug.Log ("GAMEOVER!!!");
		}

		for(int i=0;i<UIHearts.Length;i++) {
			if (i<(hearts)) { // show one less than the number of lives since you only typically show lifes after the current life in UI
				UIHearts[i].SetActive(true);
			} else {
				UIHearts[i].SetActive(false);
			}
		}
	}
}
