using UnityEngine;

public class StartSpawner : MonoBehaviour
{
    public GameObject[] possibleSpawns;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        int randomSpawn = Random.Range(0, possibleSpawns.Length);
        GameObject startSpawner = GameObject.Find("StartSpawner");
        transform.position = startSpawner.transform.position;
        transform.rotation = startSpawner.transform.rotation;

        Instantiate(possibleSpawns[randomSpawn], startSpawner.transform.position, startSpawner.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
