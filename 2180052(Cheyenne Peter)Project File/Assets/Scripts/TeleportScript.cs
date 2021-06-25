using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TeleportScript : MonoBehaviour
{
    public ScoreScript scoreScript;

    public Text keypressText;

    public GameObject GotAllTheThings;
    // Start is called before the first frame update
    void Start()
    {
        keypressText.gameObject.SetActive(false);
        GotAllTheThings.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (scoreScript.WinAmount <= scoreScript.BigTotal && scoreScript._resource1 >= 4 && scoreScript._resource2 >= 5)
        {
            Debug.Log("You got all the stuff!!!");
            GotAllTheThings.gameObject.SetActive(true);

            if (Input.GetKeyDown(KeyCode.X))
            {
                Debug.Log("Win");
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
        else if (scoreScript.WinAmount > scoreScript.BigTotal || scoreScript._resource1 < 4 || scoreScript._resource2 < 5)
        {
            GotAllTheThings.gameObject.SetActive(false);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GotAllTheThings.gameObject.SetActive(false);
            keypressText.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            keypressText.gameObject.SetActive(false);
        }
    }
}
