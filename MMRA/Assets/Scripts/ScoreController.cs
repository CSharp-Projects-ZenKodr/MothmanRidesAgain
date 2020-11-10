using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
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
    }

    private void Update()
    {
        if (currentScore == 0)
            scoreDisplayText.text = "0000";
        else if (currentScore < 100)
            scoreDisplayText.text = "00" + currentScore;
        else if (currentScore < 1000)
            scoreDisplayText.text = "0" + currentScore;
        else
            scoreDisplayText.text = currentScore.ToString();

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
        currentScore += score;
        trickDisplayText.text = text;
        displayingTrick = true;
        timeDisplayed = 0;
    }

    IEnumerable displayDelay()
    {
        yield return new WaitForSeconds(1);
    }
}
