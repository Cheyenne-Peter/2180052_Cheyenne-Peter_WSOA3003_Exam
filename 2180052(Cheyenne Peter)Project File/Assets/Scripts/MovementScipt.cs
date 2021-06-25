using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MovementScipt : MonoBehaviour
{
    private Rigidbody2D squirrelRB;

    public float moveSpeed;
    public float slowmoveSpeed;
    public float jumpVelocity;
    public float jumpHeight;
    public float slowjumpHeight;
    public int AcornNumber;

    public KeyCode RightButton, LeftButton;

    public bool isGrounded;

    public GameObject acorn;

    public int score;
    public int resource1;
    public int resource2;
    public int totalScore;

    public int health;
    public Animator playerAnim;
    // CollectionSystem collecSystem;
    // public int score;
    // Start is called before the first frame update
    void Start()
    {
        squirrelRB = GetComponent<Rigidbody2D>();

    }
    private void Update()
    {
        Move();

        if (health <= 0)
        {
            Debug.Log("You is Dead -_-");
            gameObject.SetActive(false);
            Debug.Log("You Lose");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
            
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
            Debug.Log("Quittt");
        }
    }

    void Move()
    {
        Jump();

        float HorzontalMovement = Input.GetAxisRaw("Horizontal");    
     
        if (score >= AcornNumber)
        {
            squirrelRB.velocity = new Vector2(HorzontalMovement * slowmoveSpeed, squirrelRB.velocity.y);
        }
        else
        {
            squirrelRB.velocity = new Vector2(HorzontalMovement * moveSpeed, squirrelRB.velocity.y);
        }
        
        if (HorzontalMovement < 0)
        {
            playerAnim.SetInteger("AnimState", 1);
            transform.eulerAngles = new Vector2(0, 180);
        }
        else if (HorzontalMovement > 0)
        {
            playerAnim.SetInteger("AnimState", 1);
            transform.eulerAngles = new Vector2(0, 0);
        }
        else if (HorzontalMovement == 0)
        {
            playerAnim.SetInteger("AnimState", 0);
        }
        if (isGrounded == false)
        {
            playerAnim.SetInteger("AnimState", 2);
        }
       

        //Add things for animations here
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            if (score >= AcornNumber)
            {
                squirrelRB.velocity = Vector2.up * slowjumpHeight;
            }
            else
            {
                squirrelRB.velocity = Vector2.up * jumpHeight;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Acorn")
        {
            score++;
            Debug.Log(score);
        }
        if (collision.gameObject.tag == "Resource1")
        {
            resource1++;
            Debug.Log("More" + resource1);
        }
        if (collision.gameObject.tag == "Resource2")
        {
            resource2++;
            Debug.Log("More" + resource2);
        }
       

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Patrol")
        {
            health--;
            Debug.Log("Ouch!");
        }
    }



}
