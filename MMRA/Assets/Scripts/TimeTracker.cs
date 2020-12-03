using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeTracker : MonoBehaviour
{
    private float levelTime;
    private Text timeDisplay;
    private int min, sec;

    private LevelManager levelManager;

    // Start is called before the first frame update
    void Start()
    {
        levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        timeDisplay = GetComponent<Text>();
    }

    private void Update()
    {
        levelTime = levelManager.GetTime();

        timeDisplay.text = GetTimeText(levelTime);
    }

    public static string GetTimeText(float time)
    {
        int min = (int)(time / 60);
        int sec = (int)(time % 60);

        if (sec < 10)
            return (min + ":0" + sec);
        else
            return (min + ":" + sec);
    }

}
