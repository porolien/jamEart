using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject[] gameObjects;
    public GameObject thisGameObject;
    Vector2 direction = new Vector2 (0, 0);
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnAnItemInSpace", 5f, Random.Range(5f, 10f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SpawnAnItemInSpace()
    {
        GameObject newItem = Instantiate (gameObjects[Random.Range(0, gameObjects.Length)]);
        float spawnX = 0;
        if(Random.Range(0, 2) == 0)
        {
            spawnX = -35;
        }
        else
        {
            spawnX = 35;
        }
        newItem.transform.position = new Vector3(spawnX, Random.Range(-13, 16), 0);
        if (newItem.transform.position.y < 1)
        {
            direction = new Vector2(-spawnX, Random.Range(1, 16));
        }
        else
        {
            direction = new Vector2(-spawnX, Random.Range(-13, 1));
        }
        newItem.GetComponent<ItemInSpace>().direction = direction;
    }
}
