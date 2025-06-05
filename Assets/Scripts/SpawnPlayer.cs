using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{
    public GameObject playerPrefab;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject spawnPoint = GameObject.Find("SpawnPoint");
        transform.position = spawnPoint.transform.position;
        transform.rotation = spawnPoint.transform.rotation;

        Instantiate(playerPrefab, spawnPoint.transform.position, spawnPoint.transform.rotation);
    }

}
