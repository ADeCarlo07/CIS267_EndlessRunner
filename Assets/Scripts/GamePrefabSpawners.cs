
using System.Data;
using UnityEngine;

public class GamePrefabSpawners : MonoBehaviour
{
    public float stepUpTo;
    public double delayBetweenStep;

    private float timer;
    private Vector2 gamePrefabSpawnerPos;
    public GameObject[] possiblePrefabs;
    public GameObject clouds;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= delayBetweenStep)
        {
            timer = 0;
            delayBetweenStep -= 0.0025;
            if (delayBetweenStep == 0)
            {
                delayBetweenStep = 0;
            }

            spawnRandomPrefab();

            gamePrefabSpawnerPos.y += stepUpTo;
            transform.position = new Vector3(transform.position.x, transform.position.y + stepUpTo, transform.position.z);


        }

    }

    private void spawnRandomPrefab()
    {
        int randomPrefab = Random.Range(0, possiblePrefabs.Length);
        Instantiate(possiblePrefabs[randomPrefab], transform.position, transform.rotation);
        Instantiate(clouds, transform.position, transform.rotation);
    }
}
