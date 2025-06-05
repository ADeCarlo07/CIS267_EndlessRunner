using UnityEngine;

public class SpinningSpikeball : MonoBehaviour
{
    public Transform rotationCenter;
    public float rotationRadius = 2f;
    public float speed = 2f;

    private float positionX = 0f;
    private float positionY = 0f;
    private float angle = 0f;
    

    // Update is called once per frame
    void Update()
    {
        positionX = rotationCenter.position.x + Mathf.Cos(angle) * rotationRadius;
        positionY = rotationCenter.position.y + Mathf.Sin(angle) * rotationRadius;
        transform.position = new Vector2 (positionX, positionY);
        angle = angle + Time.deltaTime * speed;

        if (angle >= 360f)
        {
            angle = 0f;
        }
    }
}
