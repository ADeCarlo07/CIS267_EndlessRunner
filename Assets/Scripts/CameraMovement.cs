using System.Collections;
using System.Collections.Generic;
using Unity.Hierarchy;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float cameraSpeed;
    public float maxCameraSpeed;
    public float delay;
    private float timer;
    private float otherTimer;
    private Coroutine coroutine;


    void Start()
    {
        coroutine = StartCoroutine(Coroutine());
    }
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= delay)
        {
            StopCoroutine(coroutine);
            move();
        }

       
    }

    private IEnumerator Coroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(delay);
        }
    }

    private void move()
    {
        otherTimer += Time.deltaTime;

        if (cameraSpeed <= maxCameraSpeed)
        {
            if (otherTimer >= 2)
            {
                otherTimer = 0;
                cameraSpeed += 0.25f;
            }
        }
        else
        {
            cameraSpeed = maxCameraSpeed;
        }

        transform.position += new Vector3(0, cameraSpeed * Time.deltaTime, 0);
    }
}
