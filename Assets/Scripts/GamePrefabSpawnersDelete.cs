using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePrefabSpawnersDelete : MonoBehaviour
{
    public float destroyAfterTime;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(delete());
        
    }

    // Update is called once per frame
    void Update()
    {
           
    }

    
    private IEnumerator delete()
    {
        yield return new WaitForSeconds(destroyAfterTime);
        Destroy(gameObject);
        
    }
    
}
