using Unity.VisualScripting;
using UnityEngine;

public class Seed : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float speed;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        seedMovement();
    }

    private void seedMovement()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Grounded"))
        {
            Destroy(this.gameObject);
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
    
       
    
}
