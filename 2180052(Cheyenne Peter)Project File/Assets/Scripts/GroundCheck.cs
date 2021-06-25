using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public MovementScipt playerScript;
    public SpriteRenderer enemyRenderer;


    public float R;
    public float G;
    public float B;

    public int hitcounter;

    private void Update()
    {
        R = Random.Range(0f, 1f);
        G = Random.Range(0f, 1f);
        B = Random.Range(0f, 1f);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            Debug.Log("Collision!!");
            playerScript.isGrounded = true;
        }

        if (collision.gameObject.tag == "Patrol")
        {
            Debug.Log("Change Colour");
            enemyRenderer.color = new Color(R, G, B);
            hitcounter++;
            playerScript.health++;
        }


    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            playerScript.isGrounded = false;
        }
    }
}
