using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckPointController : MonoBehaviour
{
    public GameObject checkpointPanel;
    public MovementScipt movemetScript;

    public bool canBank;
    // Start is called before the first frame update
    void Start()
    {
        checkpointPanel.SetActive(false);
    }

    private void Update()
    {
        if (movemetScript.score < 5)
        {
            canBank = false;
        }
        else
        {
            canBank = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            checkpointPanel.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            checkpointPanel.SetActive(false);
        }
    }

    public void BankAcorns5()
    {
        if (canBank == true)
        {
            movemetScript.score = movemetScript.score - 5;
            movemetScript.totalScore += 5;
        }
        
    }
}
