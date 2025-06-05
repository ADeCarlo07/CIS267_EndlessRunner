using UnityEngine;

public class MoveableWall : MonoBehaviour
{
    public float movementSpeed;
    public float offset;
    private float startPosY;
    private bool moveUp;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveUp = true;
        startPosY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        moveWall();
    }

    private void moveWall()
    {
        if (moveUp)
        {
            transform.Translate(Vector2.up * movementSpeed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector2.down * movementSpeed * Time.deltaTime);
        }

        if (transform.position.y >= startPosY)
        {
            moveUp = false;
        }
        else if (transform.position.y <=  startPosY - offset)
        {
            moveUp = true;
        }
    }

}
