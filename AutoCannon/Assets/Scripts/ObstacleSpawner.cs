using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject[] obstacles;
    public Transform shootPoint;
    public float timer = 3f;
    float realTimer = 0f;
    int index;
    int beforeIndex;
    // Start is called before the first frame update
    void Start()
    {
        realTimer = timer;
    }

    // Update is called once per frame
    void Update()
    {
        realTimer -= Time.deltaTime;
        if (realTimer < 0)
        {
            realTimer = timer;
            RandomIndex();
           while(index==beforeIndex)
            {
                RandomIndex();
            }
            GameObject spawnedObstacle = obstacles[index];
            spawnedObstacle.SetActive(true);
            spawnedObstacle.transform.SetParent(null);
            beforeIndex = index;

        }
    }
    void RandomIndex()
    {
        index = Random.Range(0, obstacles.Length);
    }
}
