
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    //this is a variable for a rigid body that is attached to the player
    private Rigidbody2D playerRigidBody;
    public float movementSpeed;
    public float sprintSpeed;
    public float jumpForce;
    private float inputHorizontal;
    private int maxNumJumps;
    private int numJumps;

    private bool touchingWall;
    public float drag;

    private int numFireballs;
    public Sprite shieldedPlayer;
    public Sprite standardPlayer;
    public Sprite fireballPlayer;
    public Sprite jumpyPlayer;
    private SpriteRenderer spriteRenderer;

    public GameObject fireballPrefab;
    public Transform fireballSpawnpoint;

    private bool isGrounded;
    private bool doubleJump = false;

    private int plusFiveScore = 5;
    private int plusTenScore = 10;

    public GameObject[] hearts;
    private int life;
    private bool dead = false;


    private bool invincible = false;
    private float otherTimer;
    private bool isTimer = false;
    private bool otherIsTimer = false;
    public float secondsOfDoubleJump;
    public float secondsOfShield;
    private float timeLeft;

    public static bool gameOver = false;

    private bool isJumping = false;
    public float spaceKeyTime;
    private float spaceKeyTimer;
   
    int numOfDJCol;
    int numOfSCol;
    int numOfSPCol;

    public Image doubleJumpImage;
    public Image spicyImage;
    public Image shieldImage;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        doubleJumpImage.enabled = false;
        spicyImage.enabled = false;
        shieldImage.enabled = false;

        Scoring.totalScore = 0f;
        //I can only use this component using the following line of code because the rigid body 2d
        //is attached to the player and this script is also attached to the player
        playerRigidBody = GetComponent<Rigidbody2D>();

      

        maxNumJumps = 1;
        numJumps = 1;

        spriteRenderer = GetComponent<SpriteRenderer>();

        numFireballs = 0;

        life = hearts.Length;
        numOfDJCol = 0;
        numOfSCol = 0;

    }

    // Update is called once per frame
    void Update()
    {
        Scoring.totalScore += 1 * Time.deltaTime;


        if (invincible)
        {
            otherIsTimer = true;
            otherTimer += Time.deltaTime;

            if (otherTimer >= secondsOfShield)
            {
                shieldImage.enabled = false;
                otherIsTimer = false;
                otherTimer = 0;
                secondsOfShield = 5;
                invincible = false;

                if (numFireballs > 0)
                {
                    spriteRenderer.sprite = fireballPlayer;
                }
                else if (timeLeft != secondsOfDoubleJump && doubleJump)
                {
                    spriteRenderer.sprite = jumpyPlayer;
                }
                else
                {
                    spriteRenderer.sprite = standardPlayer;
                }
            }


        }

        if (doubleJump)
        {
            isTimer = true;
            timeLeft += Time.deltaTime;

            if (timeLeft >= secondsOfDoubleJump)
            {
                doubleJumpImage.enabled = false;
                isTimer = false;
                timeLeft = 0;
                maxNumJumps = 1;
                secondsOfDoubleJump = 5;
                doubleJump = false;

                if (numFireballs > 0)
                {
                    spriteRenderer.sprite = fireballPlayer;
                }
                else if (otherTimer != secondsOfShield && invincible)
                {
                    spriteRenderer.sprite = shieldedPlayer;
                }
                else
                {
                    spriteRenderer.sprite = standardPlayer;
                }
            }


            //isTimer = true;
            //timeLeft += Time.deltaTime;
            //if (timeLeft >= secondsOfDoubleJump)
            //{
               
            //    timeLeft = 0;
            //    secondsOfDoubleJump = 5;
            //    maxNumJumps = 1;
            //    doubleJump = false;
            //    isTimer = false;

            //    if (numFireballs > 0)
            //    {
            //        spriteRenderer.sprite = fireballPlayer;
            //    }
            //    else if (otherTimer != secondsOfShield && invincible)
            //    {
            //        spriteRenderer.sprite = shieldedPlayer;
            //    }
            //    else
            //    {
            //        spriteRenderer.sprite = standardPlayer;
            //    }
                    
                

            //}
            
        }

        
        
       if (numFireballs == 0 && numOfSPCol > 0)
       {
            spicyImage.enabled = false;

            if (timeLeft != secondsOfDoubleJump && doubleJump)
            {
                if (otherTimer < timeLeft && invincible)
                {
                    spriteRenderer.sprite = shieldedPlayer;
                }
                spriteRenderer.sprite = jumpyPlayer;
            }
            if (otherTimer != secondsOfShield && invincible)
            {
                if (timeLeft < otherTimer && doubleJump)
                {
                    spriteRenderer.sprite = jumpyPlayer;
                }

                spriteRenderer.sprite = shieldedPlayer;
            }
            else
            {
                spriteRenderer.sprite = standardPlayer;
            }
       }



       if (dead == true)
       {
            gameOver = true;
            
            SceneManager.LoadScene("GameOver");

 
       }

        movePlayerLateral();
        jump();
        shootFireball();
        wallHold();

    }

    private void takeDamage()
    {
        if (life >= 1)
        {
            life--;
            Destroy(hearts[life].gameObject);

           
        }

        if (life < 1)
        {
            dead = true;
        }
    }

   
    private void movePlayerLateral()
    {
        inputHorizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetKey(KeyCode.LeftShift) && isGrounded)
        {
            playerRigidBody.linearVelocity = new Vector2(sprintSpeed * inputHorizontal, playerRigidBody.linearVelocity.y);
        }
        else
        {
            playerRigidBody.linearVelocity = new Vector2(movementSpeed * inputHorizontal, playerRigidBody.linearVelocity.y);
        }

        if (inputHorizontal != 0)
        {
            flipPlayerSprite(inputHorizontal);
        }
    }

    private void flipPlayerSprite(float inputHorizontal)
    {
        if (inputHorizontal > 0)
        {
            //Quanternion controls angled rotation
            transform.localRotation = Quaternion.Euler(0, 0, 0);
            
        }
        else if (inputHorizontal < 0)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
            
        }

    }

    private void wallHold()
    {
        if (Input.GetKey(KeyCode.J) && touchingWall)
        {
            playerRigidBody.linearDamping = drag;
        }
        else
        {
            playerRigidBody.linearDamping = 0;
        }
    }

    private void jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && numJumps <= maxNumJumps)
        {
            isJumping = true;
            spaceKeyTimer = spaceKeyTime;

            playerRigidBody.linearVelocity = new Vector2(playerRigidBody.linearVelocity.x, jumpForce);

            numJumps++;

        }

        if (Input.GetKey(KeyCode.Space) && isJumping)
        {
            if (spaceKeyTimer > 0)
            {
                spaceKeyTimer -= Time.deltaTime;
                playerRigidBody.linearVelocity = new Vector2(playerRigidBody.linearVelocity.x, jumpForce);
            }
            else
            {
                isJumping = false;
            }
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            isJumping = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Grounded"))
        {
            numJumps = 1;
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }

        if (collision.gameObject.CompareTag("Wall"))
        {
            touchingWall = true;
            if (!isGrounded)
            {
                numJumps = 1; 
            }
        
            
        }
        else
        {
            touchingWall = false;
        }

        if (collision.gameObject.CompareTag("SnappyPlant"))
        {
            if (!invincible)
            {
                takeDamage();
            }
        }

        if (collision.gameObject.CompareTag("SpinningSpikeball"))
        {
            if (!invincible)
            {
                takeDamage();
            }
        }

        if (collision.gameObject.CompareTag("SeedShooter"))
        {
            if (!invincible)
            {
                takeDamage();
            }
        }

        //if(maxNumJumps == 2 && collision.gameObject.CompareTag("Grounded"))
       // {
          //  maxNumJumps = 1;
      //  }

        


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ShieldCol"))
        {
            shieldImage.enabled = true;

            numOfSCol++;

            Scoring.totalScore += plusFiveScore;
            
            invincible = true;
            

            if (numOfSCol == 1 && otherIsTimer)
            {
                secondsOfShield = 5;
            }
            else if (secondsOfShield > 1 && otherIsTimer)
            {
                secondsOfShield += secondsOfShield;
            }


            Destroy(collision.gameObject);
            spriteRenderer.sprite = shieldedPlayer;
        }

        if (collision.gameObject.CompareTag("DoubleJumpCol"))
        {
            doubleJumpImage.enabled = true;
            numOfDJCol++;
            maxNumJumps = 2;

            Scoring.totalScore += plusFiveScore;

            doubleJump = true;


            if (numOfDJCol == 1 && isTimer)
            {
                secondsOfDoubleJump= 5;
            }
            else if (secondsOfDoubleJump > 1 && isTimer)
            {
                secondsOfDoubleJump += secondsOfDoubleJump;
            }


            Destroy(collision.gameObject);
           
            spriteRenderer.sprite = jumpyPlayer;


            //numOfDJCol++;
            
            //Scoring.totalScore += plusFiveScore;
            //doubleJump = true;
            //maxNumJumps = 2;

            //if (numOfDJCol == 1 && isTimer)
            //{
            //    secondsOfDoubleJump = 5;
            //}
            //else if (secondsOfDoubleJump > 1 && isTimer)
            //{
            //    secondsOfDoubleJump += secondsOfDoubleJump;
            //}
            
            
            //Destroy(collision.gameObject);
            //spriteRenderer.sprite = jumpyPlayer;
        }

        if (collision.gameObject.CompareTag("SpicyCol"))
        {
            spicyImage.enabled = true;
            numOfSPCol++;

            Scoring.totalScore += plusFiveScore;

            if (numFireballs == 0)
            {
                numFireballs = 5;
            }
            else
            {
                numFireballs += 5;
            }

            spriteRenderer.sprite = fireballPlayer;

            
            Destroy(collision.gameObject);
        }
        
        if (collision.gameObject.CompareTag("CoinCol"))
        {


            Scoring.totalScore += plusTenScore;
        }

       
        
        if (collision.gameObject.CompareTag("Seed"))
        {
            if (!invincible)
            {
                takeDamage();
            }
            
        }

        if (collision.gameObject.CompareTag("Border"))
        {
            gameOver = true;
            SceneManager.LoadScene("GameOver");
        }
    }


    void shootFireball()
    {
        if (Input.GetKeyDown(KeyCode.H) && numFireballs != 0)
        {
            Instantiate(fireballPrefab, fireballSpawnpoint.position, fireballSpawnpoint.rotation);
            --numFireballs;
        }

    }

}
