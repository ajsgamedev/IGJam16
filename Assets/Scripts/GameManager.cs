using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {
    public float tileWidth;
    public List<Transform> tilesInUse;
    public List<Transform> tilePool;

    Vector2 castingPoint;
	// Use this for initialization
	void Start () {
        castingPoint.x = 0;
        castingPoint.y = Screen.height;
        //horzExtent = Camera.main.orthographicSize * Screen.width / Screen.height;
	}
	
	// Update is called once per frame
	void Update () {

	}
}
