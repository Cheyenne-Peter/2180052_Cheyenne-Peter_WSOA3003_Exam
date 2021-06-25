using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreScript : MonoBehaviour
{
    public int _score;
    public Text ScoreText;

    public int _resource1;
    public Text ResourceText1;

    public int _resource2;
    public Text ResourceText2;

    public int _health;
    public Text HealthText;

    public int _totalScore;
    public Text TotalScoreText;

    public int BigTotal;

    public MovementScipt movementScript;
    //public TeleportScript teleScript;
    public int WinAmount;

    private void Update()
    {
        _score = movementScript.score;
        ScoreText.text = _score.ToString();

        _resource1 = movementScript.resource1;
        ResourceText1.text = _resource1.ToString() + "/4";

        _resource2 = movementScript.resource2;
        ResourceText2.text = _resource2.ToString() + "/5";

        _health = movementScript.health;
        HealthText.text = _health.ToString();

        _totalScore = movementScript.totalScore;
        TotalScoreText.text = _totalScore.ToString();

        BigTotal = _totalScore + _score;

        if (_resource1 <= 0)
        {
            _resource1 = 0;
        }
        if (_resource2 <= 0)
        {
            _resource2 = 0;
        }
        if (_score < 0)
        {
            _score = 0;
        }

    }
}
