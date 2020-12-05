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

    private List<string> comboArray;
    private int comboScore;    
    
    // Start is called before the first frame update
    void Start()
    {
        scoreDisplayText = GetComponent<Text>();

        trickDisplayText = GameObject.Find("TrickDisplay").GetComponent<Text>();
        trickDisplayText.text = "";

        comboArray = new List<string>();

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

                comboScore = 0;
                comboArray.Clear();
            }
        }
    }

    public void trick(int score, string text)
    {
        levelManager.AddToScore(score);

        comboScore += score;
        comboArray.Add(text);

        int kickflips = 0;
        int treflips = 0; // treflip also means 360 flip

        foreach (string trick in comboArray)
        {
            if (trick.Equals("Kickflip"))
            {
                kickflips++;
            }
            else if (trick.Equals("360 Flip"))
            {
                treflips++;
            }
        }

        string displayString = "";

        if (kickflips > 0)
        {
            displayString += "Kickflip";
            if (kickflips > 1)
                displayString += " x" + kickflips;
        }

        if (kickflips > 0 && treflips > 0)
            displayString += " + ";

        if (treflips > 0)
        {
            displayString += "360 Flip";
            if (treflips > 1)
                displayString += " x" + treflips;
        }

        displayString += "\n\n Combo: " + GetScoreText(comboScore);

        trickDisplayText.text = displayString;

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
