using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    private LevelManager levelManager;

    private Text scoreDisplayText;
    private Text trickDisplayText;
    private int currentScore = 0;

    public float trickDisplayTime = 1f;
    public float timeDisplayed = 0;
    private bool displayingTrick = false;

    // Start is called before the first frame update
    void Start()
    {
        scoreDisplayText = GetComponent<Text>();
        trickDisplayText = GameObject.Find("TrickDisplay").GetComponent<Text>();

        levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
    }

    private void Update()
    {
        currentScore = levelManager.GetScore();

        scoreDisplayText.text = GetScoreText(currentScore);

        if (displayingTrick)
        {
            timeDisplayed += Time.deltaTime;
            if (timeDisplayed >= trickDisplayTime)
            {
                trickDisplayText.text = "";
                timeDisplayed = 0;
                displayingTrick = false;
            }
        }
    }

    public void trick(int score, string text)
    {
        levelManager.AddToScore(score);

        trickDisplayText.text = text;
        displayingTrick = true;
        timeDisplayed = 0;
    }

    public static string GetScoreText(int score)
    {
        if (score == 0)
            return "0000";
        else if (score < 100)
            return "00" + score;
        else if (score < 1000)
            return "0" + score;
        else
            return score.ToString();
    }

    IEnumerable displayDelay()
    {
        yield return new WaitForSeconds(1);
    }
}
