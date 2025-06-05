using Unity.VisualScripting;
using UnityEngine;

public class MoveablePlatform : MonoBehaviour
{
    public float movementSpeed;
    public float offset;
    private float startPosX;
    private bool moveRight;
    private bool moveLeft;
    public bool goRightLeft;
    public bool goLeftRight;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveLeft = true;
        moveRight = true;
        startPosX = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        movePlatform();
    }
    private void movePlatform()
    {
        if (goLeftRight)
        {
            if (moveRight)
            {
                transform.Translate(Vector2.right * movementSpeed * Time.deltaTime);
            }
            else
            {
                transform.Translate(Vector2.left * movementSpeed * Time.deltaTime);
            }

            if (transform.position.x >= startPosX)
            {
                moveRight = false;
            }
            else if (transform.position.x <= startPosX - offset)
            {
                moveRight = true;
            }
        }

        if (goRightLeft)
        {
            if (moveLeft)
            {
                transform.Translate(Vector2.left * movementSpeed * Time.deltaTime);
            }
            else
            {
                transform.Translate(Vector2.right * movementSpeed * Time.deltaTime);
            }

            if (transform.position.x <= startPosX)
            {
                moveLeft = false;
            }
            else if (transform.position.x >= startPosX + offset)
            {
                moveLeft = true;
            }
        }
       
    }

    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.SetParent(gameObject.transform);
        }

       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("SpicyCol"))
        {
            collision.gameObject.transform.SetParent(gameObject.transform);
        }

        if (collision.gameObject.CompareTag("DoubleJumpCol"))
        {
            collision.gameObject.transform.SetParent(gameObject.transform);
        }

        if (collision.gameObject.CompareTag("ShieldCol"))
        {
            collision.gameObject.transform.SetParent(gameObject.transform);
        }

        if (collision.gameObject.CompareTag("CoinCol"))
        {
            collision.gameObject.transform.SetParent(gameObject.transform);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.SetParent(null);   
        }
    }
}
