using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
   
    [SerializeField] private GameObject[] asteroidPrefabs;
    [SerializeField] private float secondsBetweenAsteroids = 1.5f;
    [SerializeField] private Vector2 forceRange;

    private Camera mainCamera;
    private float timer;

    void Start() 
    {
        mainCamera = Camera.main;
    }
    
   //Every frame count down timer, when it reaches 0 spawn new asteroid and reset timer
    void Update()
    {
        timer -= Time.deltaTime; 

        if (time <= 0)
        {
            SpawnAsteroid();

            timer += secondsBetweenAsteroids;
        }
    }

    //To spawn asteroid, pick a random side of the screen. Based on what side is choosen, determine spawn point and force
    private void SpawnAsteroid()
    {
        int side = Random.Range(0, 4);

        Vector2 spawnPoint = Vector2.zero;
        Vector2 direction = Vector2.zero;

        switch(side) 
            {
                case 0:
                    //Left
                    spawnPoint.x = 0;
                    spawnPoint.y = Random.value;
                    direction = new Vector2(1f, Random.Range(-1f, 1f));
                    break;
                case 1:
                    //Right
                    spawnPoint.x = 1;
                    spawnPoint.y = Random.value;
                    direction = new Vector2(-1f, Random.Range(-1f, 1f));
                    break;
                case 2:
                    //Bottom
                    spawnPoint.x = Random.value;
                    spawnPoint.y = 0;
                    direction = new Vector2(Random.Range(-1f, 1f), 1f);
                    break;
                case 3:
                    //Top
                    spawnPoint.x = Random.value;
                    spawnPoint.y = 1; 
                    direction = new Vector2(Random.Range(-1f,1f), -1f);
                    break;
            }


            //Convert calculations above to worldspace for device 
            Vector3 worldSpawnPoint = mainCamera.ViewportToWorldPoint(spawnPoint);
            worldSpawnPoint.z = 0;

            //Pick random asteroid out of list
            GameObject selectedAsteroid = asteroidPrefabs[Random.Range(0, asteroidPrefabs.Length)];

            //Spawn in random asteroid from list above 
            GameObject asteroidInstance = Instantiate(
                selectedAsteroid, 
                worldSpawnPoint, 
                Quaternion.Euler(0f, 0f, Random.Range(0f, 360f)));

            RigidBody rb = asteroidInstance.GetComponent<RigidBody>();

            rb.velocity = direction.normalized * Random.Range(forceRange.x, forceRange.y);
        }
    }
}
