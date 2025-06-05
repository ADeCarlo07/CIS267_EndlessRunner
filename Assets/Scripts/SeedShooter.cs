using UnityEngine;
public class SeedShooter : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private float timer;
    public float spawnDelay;
    public GameObject seedPrefab;
    public Transform seedSpawnpoint;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > spawnDelay)
        {
            timer = 0;
            SpawnSeeds();
        }
    }
    private void SpawnSeeds()
    {
        Instantiate(seedPrefab, seedSpawnpoint.position, seedSpawnpoint.rotation);
        
    }
}
