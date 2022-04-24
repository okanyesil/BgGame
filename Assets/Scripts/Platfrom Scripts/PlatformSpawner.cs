using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject platformPrefab;
    public GameObject spikePlatformPrefab;
    public GameObject breakablePlatform;
    public GameObject[] movingPlatforms;

    public float platformSpawnTimer = 1.8f;

    private float _currentPlatformSpawnTimer;

    private int _platformSpawnCount;

    public float minX = -2f, maxX = 2f;
    // Start is called before the first frame update
    void Start()
    {
        _currentPlatformSpawnTimer = platformSpawnTimer;
    }

    // Update is called once per frame
    void Update()
    {
        SpawnPlatforms();
    }

    void SpawnPlatforms()
    {
        _currentPlatformSpawnTimer += Time.deltaTime;

        if (_currentPlatformSpawnTimer >= platformSpawnTimer)
        {
            _platformSpawnCount++;
            Vector3 temp = transform.position;
            temp.x = Random.Range(minX, maxX);
            if (_platformSpawnCount < 2)
            {
                //Debug.Log("platform spawner 2den küçük");
                GameObject newPlatform = Instantiate(platformPrefab, temp, Quaternion.identity);
                
            } 
            else if(_platformSpawnCount == 2)
            {
                //Debug.Log("platform spawner 2");
                if (Random.Range(0, 3) >= 1)
                {
                   // Debug.Log("2 >>> if work");
                    GameObject newPlatform = Instantiate(platformPrefab, temp, Quaternion.identity);
                }
                else
                {
                    //Debug.Log("2 >>> else work");
                    GameObject newPlatform = Instantiate(movingPlatforms[Random.Range(0, movingPlatforms.Length)], 
                        temp, Quaternion.identity);
                }
            }
            else if (_platformSpawnCount == 3)
            {
                //Debug.Log("platform spawner 3");
                if (Random.Range(0, 3) >= 1)
                {
                    //Debug.Log("3 >>> if work");
                    GameObject newPlatform = Instantiate(platformPrefab, temp, Quaternion.identity);
                }
                else
                {
                    //Debug.Log("3 >>> else work");
                    GameObject newPlatform = Instantiate(spikePlatformPrefab, 
                        temp, Quaternion.identity);
                }
            }
            
            else if (_platformSpawnCount == 4)
            {
                //Debug.Log("platform spawner 4");
                if (Random.Range(0, 3) > 1)
                {
                    //Debug.Log("4 >>> if work");
                    GameObject newPlatform = Instantiate(platformPrefab, temp, Quaternion.identity);
                }
                else
                {
                    //Debug.Log("4 >>> else work");
                    GameObject newPlatform = Instantiate(breakablePlatform, 
                        temp, Quaternion.identity);
                }

                _platformSpawnCount = 0;
            }

            //newPlatform.transform.parent = transform;
            _currentPlatformSpawnTimer = 0f;
        } // spawn platform
    }
}
