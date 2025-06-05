using UnityEngine;

public class Fireball : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public float speed;
    public float fireballLifeTime;
    private Vector2 lastVelocity;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Destroy(gameObject, fireballLifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        lastVelocity = rb.linearVelocity;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("SnappyPlant"))
        {
            Scoring.totalScore += 3;
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }

        if (collision.gameObject.CompareTag("SeedShooter"))
        {
            Scoring.totalScore += 3;
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }

        if (collision.gameObject.CompareTag("Seed"))
        {
            Scoring.totalScore += 1;
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }

        if (collision.gameObject.CompareTag("SpinningSpikeball"))
        {
            Scoring.totalScore += 5;
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }

      
        if (collision.gameObject.CompareTag("Grounded"))
        {
            GetComponent<Collider2D>().isTrigger = false;
        }

        if (collision.gameObject.CompareTag("Wall"))
        {
            Destroy(this.gameObject);
        }

        if (collision.gameObject.CompareTag("Border"))
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            Destroy(this.gameObject);
        }

        if (collision.gameObject.CompareTag("SnappyPlant"))
        {
            GetComponent<Collider2D>().isTrigger = true;
        }

        if (collision.gameObject.CompareTag("SeedShooter"))
        {
            GetComponent<Collider2D>().isTrigger = true;
        }

        if (collision.gameObject.CompareTag("Seed"))
        {
            GetComponent<Collider2D>().isTrigger = true;
        }

        if (collision.gameObject.CompareTag("SpinningSpikeball"))
        {
            GetComponent<Collider2D>().isTrigger = true;
        }

        if (collision.gameObject.CompareTag("SnappyPlant"))
        {
            Scoring.totalScore += 3;
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }

        if (collision.gameObject.CompareTag("SeedShooter"))
        {
            Scoring.totalScore += 3;
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }

        if (collision.gameObject.CompareTag("Seed"))
        {
            Scoring.totalScore += 1;
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }

        if (collision.gameObject.CompareTag("SpinningSpikeball"))
        {
            Scoring.totalScore += 5;
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }
    }

    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("SnappyPlant"))
        {
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("Grounded"))
        {
            GetComponent<Collider2D>().isTrigger = false;
        }
    }*/

}
