﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {



	public int hearts = 3;
	public GameObject[] UIHearts;

	public float tileWidth;
    public float minimumFreeSpace;
    float freeSpaceCounter;
    float screenInMeters;

    public float backgroundScrollingSpeed;
    public float middlegroundScrollingSpeed;

    public List<Transform> tilesInUse;
    public List<Transform> tilePool;

    public List<Transform> obstaclesInUse;
    public List<Transform> obstaclePool;

    public List<Transform> normalBirdsInUse;
    public List<Transform> normalBirdPool;

    public List<Transform> bigBirdsInUse;
    public List<Transform> bigBirdPool;

    public List<Transform> middleGroundInUse;
    public List<Transform> middleGroundPool;

    public List<Transform> backGroundInUse;
    public List<Transform> backGroundPool;

    float movedDistance = 0;
    float movedMiddleDistance = 0;
    float movedBackDistance = 0;
    Vector3 lastPos;

    public static GameManager instance;
    public Player player;

    //ObstacleSpawnStuff
    public int nextObstacleSpawnInterval;
    int currentObstacleSpawnInterval;

    //SmallBirdSpawnStuff
    public int nextBirdSpawnInterval;
    int currentBirdSpawnInterval;

    //BigBirdSpawnStuff
    public int nextBigBirdSpawnInterval;
    int currentBigBirdSpawnInterval;

	// Use this for initialization
	void Start () {
        currentObstacleSpawnInterval = nextObstacleSpawnInterval;
        SetupTiles();
        instance = this;
        player = FindObjectOfType<Player>();
        //movedMiddleDistance = -screenInMeters;
        //movedBackDistance = -screenInMeters;
	}

    void SetupTiles()
    {
        screenInMeters = Camera.main.orthographicSize * Screen.width / Screen.height;
        screenInMeters *= 2;
        int tilesNeeded = (int)(screenInMeters / tileWidth) + 3;
        float startPoint = screenInMeters * -0.5f;
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
        currentObstacleSpawnInterval--;
        currentBirdSpawnInterval--;
        currentBigBirdSpawnInterval--;
        freeSpaceCounter--;

        if(freeSpaceCounter <= 0 && currentObstacleSpawnInterval <= 0)
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
            currentObstacleSpawnInterval += nextObstacleSpawnInterval;
            freeSpaceCounter = minimumFreeSpace;
        }

        if (freeSpaceCounter <= 0 && currentBigBirdSpawnInterval <= 0)
        {
            int randomNumber2 = Random.Range(0, bigBirdPool.Count);
            bigBirdPool[randomNumber2].localPosition = lastPos;
            bigBirdsInUse.Add(bigBirdPool[randomNumber2]);
            bigBirdPool.RemoveAt(randomNumber2);

            //Just to ensure the removing happens late enough
            if (bigBirdsInUse.Count > 3)
            {
                bigBirdPool.Add(bigBirdsInUse[0]);
                bigBirdsInUse.RemoveAt(0);
            }
            currentBigBirdSpawnInterval += nextBigBirdSpawnInterval;
            freeSpaceCounter = minimumFreeSpace;
        }

        if (freeSpaceCounter <= 0 && currentBirdSpawnInterval <= 0)
        {
            int randomNumber2 = Random.Range(0, normalBirdPool.Count);
            normalBirdPool[randomNumber2].localPosition = lastPos;
            normalBirdsInUse.Add(normalBirdPool[randomNumber2]);
            normalBirdPool.RemoveAt(randomNumber2);

            //Just to ensure the removing happens late enough
            if (normalBirdsInUse.Count > 3)
            {
                normalBirdPool.Add(normalBirdsInUse[0]);
                normalBirdsInUse.RemoveAt(0);
            }
            currentBirdSpawnInterval += nextBirdSpawnInterval;
            freeSpaceCounter = minimumFreeSpace;
        }

    }

	// Update is called once per frame
	void Update () {
        movedDistance += Player.runningSpeed * Time.deltaTime;
        movedMiddleDistance += middlegroundScrollingSpeed * Time.deltaTime;
        movedBackDistance += backgroundScrollingSpeed * Time.deltaTime;

        if(movedDistance >= tileWidth)
        {
            movedDistance -= tileWidth;
            lastPos.x += tileWidth;
            tilePool.Add(tilesInUse[0]);
            tilesInUse.RemoveAt(0);

            CreateTile();
        }

        if (movedMiddleDistance >= screenInMeters)
        {
            int RandomMiddle = Random.Range(0,middleGroundPool.Count);
            middleGroundPool[RandomMiddle].position = lastPos;
            middleGroundInUse.Add(middleGroundPool[RandomMiddle]);
            middleGroundPool.RemoveAt(RandomMiddle);

            if(middleGroundInUse.Count > 1)
            {
                middleGroundPool.Add(middleGroundInUse[0]);
                middleGroundInUse.RemoveAt(0);
            }

            movedMiddleDistance -= screenInMeters;
        }

        if (movedBackDistance >= screenInMeters)
        {
            int RandomBack = Random.Range(0, backGroundPool.Count);
            backGroundPool[RandomBack].position = lastPos;
            backGroundInUse.Add(backGroundPool[RandomBack]);
            backGroundPool.RemoveAt(RandomBack);

            if(backGroundInUse.Count > 1)
            {
                backGroundPool.Add(backGroundInUse[0]);
                backGroundInUse.RemoveAt(0);
            }

            movedBackDistance -= screenInMeters;
        }



        //MiddleGroundStuff
        for(int i = 0; i < middleGroundInUse.Count;i++)
        {
            middleGroundInUse[i].Translate(middlegroundScrollingSpeed * Time.deltaTime, 0, 0);
        }
        //BackgroundStuff
        for(int j = 0; j < backGroundInUse.Count;j++)
        {
            backGroundInUse[j].Translate(backgroundScrollingSpeed * Time.deltaTime,0,0);
        }
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
