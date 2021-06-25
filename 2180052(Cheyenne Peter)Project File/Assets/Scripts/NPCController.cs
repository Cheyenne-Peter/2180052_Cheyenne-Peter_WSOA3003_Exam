using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCController : MonoBehaviour
{
    public float speed;
    public float distance;
    public bool MovingRight = true;
    public Transform groundDetector;
    public GameObject fox;

    public GameObject npcPanel;
    public GameObject Berry;
    public GameObject Twig;
    public bool canPurchase;
    public bool TwigBuy;
    public bool BerryBuy;

    public MovementScipt movementScript;
    public GroundCheck groundCheck;
    
    // Start is called before the first frame update
    void Start()
    {
        npcPanel.SetActive(false);
        Berry.SetActive(true);
        Twig.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.tag == "Patrol")
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);

            RaycastHit2D GroundInfo = Physics2D.Raycast(groundDetector.position, Vector2.down, distance);
            if (GroundInfo.collider == false)
            {
                if (MovingRight == true)
                {
                    transform.eulerAngles = new Vector3(0, -180, 0);
                    MovingRight = false;
                }
                else 
                {
                    transform.eulerAngles = new Vector3(0, 0, 0);
                    MovingRight = true;
                }
            }

            if (groundCheck.hitcounter == 2)
            {
                Destroy(fox);
            }
        }

        if (movementScript.score < 2 || movementScript.score < 2)
        {
            canPurchase = false;
        }
        else
        {
            canPurchase = true;
        }

        if (movementScript.resource1 >= 4)
        {
            TwigBuy = false;
            Twig.SetActive(false);
        }
        else
        {
            TwigBuy = true;
        }

        if (movementScript.resource2 >= 5)
        {
            BerryBuy = false;
            Berry.SetActive(false);
        }
        else
        {
            BerryBuy = true;
        }

    }


    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (gameObject.tag == "Patrol")
        {
            if (collision.gameObject.CompareTag("Player"))
            {

                if (MovingRight == false)
                {
                    Debug.Log("COLLISION!!!");
                    transform.eulerAngles = new Vector3(0, 0, 0);
                }
                else
                {
                    transform.eulerAngles = new Vector3(0, -180, 0);
                }
            }
        }
    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        if (gameObject.tag == "Patrol")
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                StartCoroutine(ChangeDirection());
            }
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameObject.tag == "NPC")
        {
            if (collision.gameObject.tag == "Player")
            {
                npcPanel.SetActive(true);
            }  
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (gameObject.tag == "NPC")
        {
            if (collision.gameObject.tag == "Player")
            {
                npcPanel.SetActive(false);
            }
        }
    }
    IEnumerator ChangeDirection()
    {
        if (MovingRight == false)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            yield return new WaitForSeconds(2f);
            transform.eulerAngles = new Vector3(0, -180, 0);
        }
        else
        {
            transform.eulerAngles = new Vector3(0, -180, 0);
            yield return new WaitForSeconds(2f);
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        
    }

    public void NewResource1()
    {
        if (canPurchase == true)
        {
            movementScript.resource1++;
            movementScript.score -= 2;
        }
    }

    public void NewResource2()
    {
        if (canPurchase == true)
        {
            movementScript.resource2++;
            movementScript.score -= 2;
        }
    }
}
