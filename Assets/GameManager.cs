using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public GameObject obstaclePrefab;
    public GameObject obstacleContainer;

    public float platformY = -1.52f;

    public static GameManager Instance;

    [HideInInspector]
    public  float screenWidthInUnit = 10;

    private void Awake()
    {
        Instance = this;
        screenWidthInUnit = (float)Screen.width / Screen.height * (Camera.main.orthographicSize * 2);
    }

    // Use this for initialization
    void Start () {
        

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SpawnObstacle(float startX, float startY)
    {
        GameObject newObstacle = GameObject.Instantiate(obstaclePrefab);
        float posX = Random.Range(startX, startY);
        newObstacle.transform.position = new Vector3(posX, platformY);
        newObstacle.transform.parent = obstacleContainer.transform;

    }
}
