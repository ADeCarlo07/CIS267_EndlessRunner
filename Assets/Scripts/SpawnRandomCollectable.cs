using UnityEngine;

public class SpawnRandomCollectable : MonoBehaviour
{
    public GameObject[] collectables;
    private Transform collectableSpawnpoint;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        collectableSpawnpoint = transform.GetComponent<Transform>();
        spawnCollectable();
    }
    private void spawnCollectable()
    {
        int randomCollectable = Random.Range(0, collectables.Length);
        Instantiate(collectables[randomCollectable], collectableSpawnpoint.transform.position, collectableSpawnpoint.transform.rotation);
    }
}
